using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Required for Chart controls
using MySqlConnector;
using System.Drawing;

namespace LogIn_HiveStock
{
    public partial class AdminSide : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;
        private readonly System.Windows.Forms.Timer orderRefreshTimer =
        new System.Windows.Forms.Timer { Interval = 5000 };   // 5 seconds
        private string lastOrderSignature = "";
        private readonly LogIn_Register loginForm;   // the login form to return to on logout
        private bool loggingOut;

        // One grid row of the order table (one row per product of an order).
        private class OrderRow
        {
            public object[] Cells;
            public int OrderItemId;
            public bool Received;
            public int OrderId;
            public string PaymentStatus;
        }

        // The grids are filled from these lists, so searching does not need the database again.
        private readonly List<object[]> productRows = new List<object[]>();
        private readonly List<OrderRow> orderRows = new List<OrderRow>();

        public AdminSide()
        {
            InitializeComponent();

            // Stops the designer from loading components/charts while you edit
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            this.Load += AdminSide_Load;   // the designer never attached this
        }

        private readonly bool isAdmin;
        private readonly string staffName = "";
        public AdminSide(string staffName, string staffIdNumber, string role, LogIn_Register login) : this()
        {
            loginForm = login;
            this.staffName = staffName;
            isAdmin = string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);

            StaffName_Label.Text = staffName;
            StaffIDNumber_Label.Text = staffIdNumber + " (" + (isAdmin ? "Admin" : "Staff") + ")";
        }

        private void View_Button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an order row first, then press View.",
                    "View Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OrderRow row = dataGridView1.SelectedRows[0].Tag as OrderRow;
            if (row == null) return;

            using (OrderDetails details = new OrderDetails(row.OrderId, isAdmin, staffName))
            {
                details.ShowDialog(this);
                if (details.Changed) LoadAdminData();   // a payment was verified or rejected
            }
        }

        private void AdminSide_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            SetupGrid(DataTable, false);
            SetupGrid(dataGridView1, true);   // several order rows can be selected and completed together

            // Per-product status plus the status of the whole transaction.
            Status.HeaderText = "Item Status";
            if (!dataGridView1.Columns.Contains("TransactionStatus"))
            {
                dataGridView1.Columns.Add("TransactionStatus", "Transaction Status");
                dataGridView1.Columns["TransactionStatus"].Width = 190;
            }

            Search_Input.TextChanged += (s, ev) => FillProductGrid();
            OMSearch_Input.TextChanged += (s, ev) => FillOrderGrid();
            Delete_Button.Click += Delete_Button_Click;
            Complete_Button.Click += Complete_Button_Click;
            View_Button.Click += View_Button_Click;
            orderRefreshTimer.Tick += OrderRefreshTimer_Tick;
            orderRefreshTimer.Start();

            // Closing the admin window with the X closes the whole app (logout does not).
            this.FormClosed += (s, ev) =>
            {
                orderRefreshTimer.Stop();
                orderRefreshTimer.Dispose();
                if (!loggingOut) Application.Exit();
            };

            ApplyRolePermissions();
            ShowPanel(AdminDashboard_Panel);
        }

        // A query that changes whenever an order is placed, verified, rejected or handed over.
        private string GetOrderSignature()
        {
            using (MySqlConnection conn = OpenConnection())
            using (MySqlCommand cmd = new MySqlCommand(
                @"SELECT COUNT(*), COALESCE(MAX(order_id), 0), COALESCE(SUM(is_completed), 0),
                 COALESCE(SUM(payment_status = 'Paid'), 0),
                 COALESCE(SUM(payment_status = 'Rejected'), 0),
                 (SELECT COALESCE(SUM(is_received), 0) FROM customer_order_items)
          FROM customer_orders", conn))
            using (MySqlDataReader r = cmd.ExecuteReader())
            {
                r.Read();
                return r[0] + "|" + r[1] + "|" + r[2] + "|" + r[3] + "|" + r[4] + "|" + r[5];
            }
        }

        private void OrderRefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                string signature = GetOrderSignature();
                if (signature == lastOrderSignature) return;   // nothing new

                lastOrderSignature = signature;
                LoadOrders();            // order cards, dashboard cards and the order grid
                LoadDashboardExtras();  // Highest-Demand Products depends on orders too
            }
            catch
            {
                // database busy or offline: simply try again on the next tick
            }
        }

        // Staff can view and search everything and hand over paid orders, but cannot change products.
        private void ApplyRolePermissions()
        {
            Create_Button.Enabled = isAdmin;
            Edit_Button.Enabled = isAdmin;
            Delete_Button.Enabled = isAdmin;
        }

        private bool RequireAdmin()
        {
            if (isAdmin) return true;

            MessageBox.Show("Only an administrator can do this.", "Access Denied",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private static void SetupGrid(DataGridView grid, bool multiSelect)
        {
            grid.AllowUserToAddRows = false;      // no blank row at the bottom
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.MultiSelect = multiSelect;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ShowPanel(Panel panel)
        {
            AdminDashboard_Panel.Visible = false;
            Product_Mgmt_Panel.Visible = false;
            OrderManagement_Panel.Visible = false;

            panel.Visible = true;

            // Reload every time a panel is shown, so new student orders and products appear.
            LoadAdminData();
        }

        private void AdminDashboard_Button_Click(object sender, EventArgs e)
        {
            ShowPanel(AdminDashboard_Panel);
        }

        private void ProductManagement_Button_Click_1(object sender, EventArgs e)
        {
            ShowPanel(Product_Mgmt_Panel);
        }

        private void Notification_Button_Click(object sender, EventArgs e)
        {
            ShowPanel(OrderManagement_Panel);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void LogOut_Button_Click_1(object sender, EventArgs e)
        {
            loggingOut = true;

            if (loginForm != null)
                loginForm.ReturnToLogin();
            else
                new LogIn_Register().Show();

            this.Close();
        }

        // ================= Product Management buttons =================

        private void Create_Button_Click(object sender, EventArgs e)
        {
            if (!RequireAdmin()) return;
            PM_CreateProduct createProductForm = new PM_CreateProduct();
            if (createProductForm.ShowDialog() == DialogResult.OK)
                LoadAdminData();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (!RequireAdmin()) return;
            int selectedId = 0;
            if (DataTable.SelectedRows.Count > 0)
                int.TryParse(Convert.ToString(DataTable.SelectedRows[0].Cells["ProductID_PM"].Value), out selectedId);

            PM_EditProduct editProductForm = new PM_EditProduct(selectedId);
            if (editProductForm.ShowDialog() == DialogResult.OK)
                LoadAdminData();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (!RequireAdmin()) return;
            if (DataTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the product you want to delete in the table first.",
                    "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = DataTable.SelectedRows[0];
            int productId = Convert.ToInt32(row.Cells["ProductID_PM"].Value);
            string name = Convert.ToString(row.Cells["ProductName_PM"].Value);

            DialogResult answer = MessageBox.Show(
                "Delete \"" + name + "\" (Product ID " + productId + ")?\n\n" +
                "This cannot be undone. It is also removed from students' carts. " +
                "Past orders keep the product name.",
                "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = OpenConnection())
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM cart_items WHERE product_id = @id", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM product WHERE product_id = @id", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                }

                LoadAdminData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete the product: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= Order Management: Complete button =================

        private void Complete_Button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the order row(s) you want to hand over first.",
                    "Complete Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<int> ids = new List<int>();
            HashSet<int> touchedOrders = new HashSet<int>();
            bool unpaidSelected = false;

            foreach (DataGridViewRow gridRow in dataGridView1.SelectedRows)
            {
                OrderRow row = gridRow.Tag as OrderRow;
                if (row == null || row.Received) continue;

                if (row.PaymentStatus != OrderManager.PaymentPaid) { unpaidSelected = true; continue; }
                ids.Add(row.OrderItemId);
                touchedOrders.Add(row.OrderId);
            }

            if (ids.Count == 0)
            {
                MessageBox.Show(unpaidSelected
                    ? "These items cannot be handed over yet because their payment is not verified. An administrator can verify it under View."
                    : "The selected item(s) are already completed.",
                    "Complete Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = "Hand over " + ids.Count + (ids.Count == 1 ? " item" : " items") +
                             " to the student and mark as received?\n\nThis cannot be undone.";
            if (unpaidSelected)
                message += "\n\n(Selected items still waiting for payment verification are skipped.)";

            if (MessageBox.Show(message, "Complete Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int released = OrderManager.ReleaseItems(ids, staffName);
            LoadAdminData();

            if (released > 0)
            {
                List<string> completedOrders = touchedOrders
                    .Where(id => orderRows.Where(r => r.OrderId == id).All(r => r.Received))
                    .OrderBy(id => id)
                    .Select(id => "HS-" + id.ToString("D4"))
                    .ToList();

                string done = released == 1
                    ? "1 item was handed over and marked as received."
                    : released + " items were handed over and marked as received.";

                if (completedOrders.Count > 0)
                    done += "\n\nTransaction completed: " + string.Join(", ", completedOrders);

                MessageBox.Show(done, "Order Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ================= Loading data from the database =================

        private void LoadAdminData()
        {
            TriggerRestockNotifications();
            LoadProducts();
            LoadOrders();
            LoadDashboardExtras();
            LoadChartData();
            LoadChart8Data(); // <--- Populates chart8 with days of the week from received_at
        }

        private void TriggerRestockNotifications()
        {
            try
            {
                using (MySqlConnection conn = OpenConnection())
                {
                    string notifQuery = @"UPDATE notification_subscription ns
                                         JOIN product p ON ns.product_id = p.product_id
                                         SET ns.status = 'SENT',
                                             ns.notified_at = NOW()
                                         WHERE ns.status = 'PENDING'
                                           AND (LOWER(p.stock_status) IN ('in stock', 'low stock', 'on stock') 
                                                 OR p.stock_qty > 0)";

                    using (MySqlCommand cmd = new MySqlCommand(notifQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error triggering restock notifications: " + ex.Message);
            }
        }

        private MySqlConnection OpenConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        private static string CategoryName(int categoryId)
        {
            switch (categoryId)
            {
                case 1: return "Books";
                case 2: return "ID Lace";
                case 3: return "Uniform";
                default: return "Other";
            }
        }

        private static string TransactionStatus(int itemCount, int receivedCount)
        {
            if (receivedCount >= itemCount) return "Completed";
            if (receivedCount == 0) return "Pending Pickup";
            return "Partially Received (" + receivedCount + " of " + itemCount + ")";
        }

        private void LoadProducts()
        {
            productRows.Clear();
            int inStock = 0, lowStock = 0, outOfStock = 0;

            try
            {
                using (MySqlConnection conn = OpenConnection())
                using (MySqlCommand cmd = new MySqlCommand(
                    @"SELECT product_id, product_name, category_id, description, price, stock_qty, stock_status
                      FROM product ORDER BY product_id", conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        string status = r["stock_status"].ToString().Trim();

                        switch (status.ToLower())
                        {
                            case "in stock":
                            case "on stock":
                                inStock++; break;
                            case "low stock":
                                lowStock++; break;
                            case "out of stock":
                            case "no stock":
                                outOfStock++; break;
                        }

                        productRows.Add(new object[]
                        {
                            r["product_id"],
                            r["product_name"].ToString().Trim(),
                            CategoryName(Convert.ToInt32(r["category_id"])),
                            r["description"].ToString().Trim(),
                            Convert.ToDecimal(r["price"]).ToString("N2"),
                            r["stock_qty"],
                            status
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the products: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TP_Counter.Text = productRows.Count.ToString();
            IS_Counter.Text = inStock.ToString();
            LS_Counter.Text = lowStock.ToString();
            OOS_Counter.Text = outOfStock.ToString();

            ADTO_Counter.Text = productRows.Count.ToString();
            ADIS_Counter.Text = inStock.ToString();
            ADLS_Counter.Text = lowStock.ToString();
            ADOOS_Counter.Text = outOfStock.ToString();

            FillProductGrid();
        }

        private void FillProductGrid()
        {
            string q = (Search_Input.Text ?? "").Trim().ToLower();

            DataTable.Rows.Clear();
            foreach (object[] row in productRows)
            {
                if (q.Length == 0 || row.Any(c => c.ToString().ToLower().Contains(q)))
                    DataTable.Rows.Add(row);
            }
        }

        private void LoadOrders()
        {
            orderRows.Clear();
            int totalOrders = 0, completedOrders = 0, rejectedOrders = 0;

            try
            {
                using (MySqlConnection conn = OpenConnection())
                {
                    Dictionary<string, string> names =
                        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT id_number, first_name, last_name FROM users", conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            names[r["id_number"].ToString().Trim()] =
                                (r["first_name"].ToString().Trim() + " " + r["last_name"].ToString().Trim()).Trim();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT o.order_id, o.user_key, o.placed_at, o.receipt_file, o.payment_status,
                         i.order_item_id, i.product_name, i.quantity, i.unit_price, i.is_received,
                         (SELECT COUNT(*) FROM customer_order_items x
                          WHERE x.order_id = o.order_id) AS item_count,
                         (SELECT COUNT(*) FROM customer_order_items x
                          WHERE x.order_id = o.order_id AND x.is_received = 1) AS received_count
                  FROM customer_orders o
                  JOIN customer_order_items i ON i.order_id = o.order_id
                  ORDER BY o.placed_at DESC, o.order_id DESC, i.order_item_id", conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string studentNo = r["user_key"].ToString().Trim();
                            string studentName;
                            if (!names.TryGetValue(studentNo, out studentName))
                                studentName = "(unknown)";

                            int quantity = Convert.ToInt32(r["quantity"]);
                            decimal total = Convert.ToDecimal(r["unit_price"]) * quantity;
                            bool received = Convert.ToInt32(r["is_received"]) != 0;
                            int itemCount = Convert.ToInt32(r["item_count"]);
                            int receivedCount = Convert.ToInt32(r["received_count"]);
                            string payment = r["payment_status"].ToString();

                            orderRows.Add(new OrderRow
                            {
                                OrderId = Convert.ToInt32(r["order_id"]),
                                OrderItemId = Convert.ToInt32(r["order_item_id"]),
                                Received = received,
                                PaymentStatus = payment,
                                Cells = new object[]
                                {
                            "HS-" + Convert.ToInt32(r["order_id"]).ToString("D4"),
                            studentNo,
                            studentName,
                            r["product_name"].ToString(),
                            quantity,
                            "\u20B1" + total.ToString("N2"),
                            Convert.ToDateTime(r["placed_at"]).ToString("dd MMM yyyy h:mm tt", CultureInfo.InvariantCulture),
                            r["receipt_file"] == DBNull.Value ? "" : r["receipt_file"].ToString(),
                            received ? "Received" : "Pending",
                            OrderManager.TransactionStatus(payment, itemCount, receivedCount)
                                }
                            });
                        }
                    }

                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT COUNT(*), COALESCE(SUM(is_completed), 0),
                         COALESCE(SUM(payment_status = 'Rejected'), 0)
                  FROM customer_orders", conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            totalOrders = Convert.ToInt32(r[0]);
                            completedOrders = Convert.ToInt32(r[1]);
                            rejectedOrders = Convert.ToInt32(r[2]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the orders: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int pendingOrders = totalOrders - completedOrders - rejectedOrders;

            OMTO_Counter.Text = totalOrders.ToString();
            OMPP_Counter.Text = pendingOrders.ToString();
            OMOC_Counter.Text = completedOrders.ToString();

            TO_Counter.Text = totalOrders.ToString();
            PP_Counter.Text = pendingOrders.ToString();
            OC_Counter.Text = completedOrders.ToString();

            FillOrderGrid();
        }

        private static readonly Color VerifyingColor = Color.FromArgb(255, 224, 178);
        private static readonly Color ReadyColor = Color.FromArgb(255, 246, 200);
        private static readonly Color RejectedColor = Color.FromArgb(248, 213, 213);

        private static void StyleOrderRow(DataGridViewRow gridRow, OrderRow row)
        {
            if (row.Received)
                gridRow.DefaultCellStyle.ForeColor = Color.DimGray;
            else if (row.PaymentStatus == OrderManager.PaymentRejected)
                gridRow.DefaultCellStyle.BackColor = RejectedColor;
            else if (row.PaymentStatus == OrderManager.PaymentPaid)
                gridRow.DefaultCellStyle.BackColor = ReadyColor;
            else
                gridRow.DefaultCellStyle.BackColor = VerifyingColor;
        }

        private void FillOrderGrid()
        {
            string q = (OMSearch_Input.Text ?? "").Trim().ToLower();

            HashSet<int> selectedIds = new HashSet<int>();
            foreach (DataGridViewRow selected in dataGridView1.SelectedRows)
            {
                OrderRow selectedRow = selected.Tag as OrderRow;
                if (selectedRow != null) selectedIds.Add(selectedRow.OrderItemId);
            }
            int firstVisible = dataGridView1.FirstDisplayedScrollingRowIndex;

            dataGridView1.Rows.Clear();
            foreach (OrderRow row in orderRows.OrderBy(o => o.Received ? 1 : 0))
            {
                if (q.Length == 0 || row.Cells.Any(c => c.ToString().ToLower().Contains(q)))
                {
                    int index = dataGridView1.Rows.Add(row.Cells);
                    DataGridViewRow gridRow = dataGridView1.Rows[index];
                    gridRow.Tag = row;
                    StyleOrderRow(gridRow, row);
                }
            }

            dataGridView1.ClearSelection();
            foreach (DataGridViewRow gridRow in dataGridView1.Rows)
            {
                OrderRow r = gridRow.Tag as OrderRow;
                if (r != null && selectedIds.Contains(r.OrderItemId)) gridRow.Selected = true;
            }
            if (firstVisible >= 0 && firstVisible < dataGridView1.Rows.Count)
            {
                try { dataGridView1.FirstDisplayedScrollingRowIndex = firstVisible; } catch { }
            }
        }

        private void LoadDashboardExtras()
        {
            Label[] updateNames = { P1, P2, P3 };
            Label[] updateDates = { PD1, PD2, PD3 };
            Label[] demandNames = { HDP_P1, HDP_P2, HDP_P3, HDP_P4, HDP_P5, HDP_P6, HDP_P7 };
            Label[] demandCounts = { TR1_Counter, TR2_Counter, TR3_Counter, TR4_Counter, TR5_Counter, TR6_Counter, TR7_Counter };

            foreach (Label l in updateNames.Concat(updateDates).Concat(demandNames).Concat(demandCounts))
                l.Text = "";

            try
            {
                using (MySqlConnection conn = OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT product_name, updated_at FROM product ORDER BY updated_at DESC, product_id DESC LIMIT 3", conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (i < 3 && r.Read())
                        {
                            updateNames[i].Text = r["product_name"].ToString().Trim();
                            updateDates[i].Text = "Updated - " + Convert.ToDateTime(r["updated_at"])
                                .ToString("MMMM d, yyyy h:mm tt", CultureInfo.InvariantCulture);
                            i++;
                        }
                    }

                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT MAX(product_name) AS product_name, SUM(quantity) AS total_qty
                          FROM customer_order_items
                          GROUP BY product_id
                          ORDER BY total_qty DESC, product_id
                          LIMIT 7", conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (i < 7 && r.Read())
                        {
                            demandNames[i].Text = r["product_name"].ToString();
                            demandCounts[i].Text = Convert.ToInt32(r["total_qty"]).ToString();
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the dashboard details: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= Load Chart Data (chart1 Pie Graph) =================
        private void LoadChartData()
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || chart1 == null)
                return;

            try
            {
                chart1.Series.Clear();
                Series series = chart1.Series.Add("Demand");
                series.ChartType = SeriesChartType.Pie;

                series["PieLabelStyle"] = "Inside";
                series.IsValueShownAsLabel = true;
                series.Label = "#PERCENT{P1}";

                if (chart1.Legends.Count > 0)
                {
                    chart1.Legends[0].Enabled = true;
                    chart1.Legends[0].Docking = Docking.Bottom;
                    chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
                }

                using (MySqlConnection conn = OpenConnection())
                {
                    string query = @"SELECT MAX(product_name) AS product_name, SUM(quantity) AS total_qty
                                     FROM customer_order_items
                                     GROUP BY product_id
                                     ORDER BY total_qty DESC, product_id
                                     LIMIT 5";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productName = reader["product_name"].ToString();
                            int totalQty = Convert.ToInt32(reader["total_qty"]);

                            int pointIndex = series.Points.AddXY(productName, totalQty);
                            series.Points[pointIndex].LegendText = productName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading chart data: " + ex.Message);
            }
        }

        // ================= Load Chart 8 Data (Converted from received_at to Day of Week) =================
        private void LoadChart8Data()
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || chart8 == null)
                return;

            try
            {
                chart8.Series.Clear();
                Series series = chart8.Series.Add("OrdersByDay");
                series.ChartType = SeriesChartType.Column;

                // Hides the series legend label entirely
                series.IsVisibleInLegend = false;

                // Initialize standard days of the week mapping counts to 0
                Dictionary<string, int> dayCounts = new Dictionary<string, int>
        {
            { "Monday", 0 },
            { "Tuesday", 0 },
            { "Wednesday", 0 },
            { "Thursday", 0 },
            { "Friday", 0 },
            { "Saturday", 0 },
            { "Sunday", 0 }
        };

                using (MySqlConnection conn = OpenConnection())
                {
                    string query = "SELECT received_at FROM customer_order_items WHERE received_at IS NOT NULL";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (DateTime.TryParse(reader["received_at"].ToString(), out DateTime receivedDate))
                            {
                                string dayName = receivedDate.DayOfWeek.ToString();
                                if (dayCounts.ContainsKey(dayName))
                                {
                                    dayCounts[dayName]++;
                                }
                            }
                        }
                    }
                }

                string[] orderedDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                foreach (string day in orderedDays)
                {
                    series.Points.AddXY(day, dayCounts[day]);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading chart8 data: " + ex.Message);
            }
        }

        private void AdminDashboard_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}