using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;

namespace LogIn_HiveStock
{
    public partial class AdminSide : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        private readonly LogIn_Register loginForm;   // the login form to return to on logout
        private bool loggingOut;

        // One grid row of the order table (one row per product of an order).
        private class OrderRow
        {
            public object[] Cells;
            public int OrderItemId;
            public bool Received;
            public int OrderId;
        }

        // The grids are filled from these lists, so searching does not need the database again.
        private readonly List<object[]> productRows = new List<object[]>();
        private readonly List<OrderRow> orderRows = new List<OrderRow>();

        public AdminSide()
        {
            InitializeComponent();
            this.Load += AdminSide_Load;   // the designer never attached this
        }

        public AdminSide(string staffName, string staffIdNumber, LogIn_Register login) : this()
        {
            loginForm = login;
            StaffName_Label.Text = staffName;
            StaffIDNumber_Label.Text = staffIdNumber;
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

            using (OrderDetails details = new OrderDetails(row.OrderId))
                details.ShowDialog(this);
        }

        private void AdminSide_Load(object sender, EventArgs e)
        {
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

            // Closing the admin window with the X closes the whole app (logout does not).
            this.FormClosed += (s, ev) => { if (!loggingOut) Application.Exit(); };

            ShowPanel(AdminDashboard_Panel);
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
            PM_CreateProduct createProductForm = new PM_CreateProduct();
            if (createProductForm.ShowDialog() == DialogResult.OK)
                LoadAdminData();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            // If a product is selected in the table, open the form with it already loaded.
            int selectedId = 0;
            if (DataTable.SelectedRows.Count > 0)
                int.TryParse(Convert.ToString(DataTable.SelectedRows[0].Cells["ProductID_PM"].Value), out selectedId);

            PM_EditProduct editProductForm = new PM_EditProduct(selectedId);
            if (editProductForm.ShowDialog() == DialogResult.OK)
                LoadAdminData();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
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

        // Marks the selected order rows (products) as picked up / completed.
        private void Complete_Button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the order row(s) you want to complete first.",
                    "Complete Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<int> ids = new List<int>();
            foreach (DataGridViewRow gridRow in dataGridView1.SelectedRows)
            {
                OrderRow row = gridRow.Tag as OrderRow;
                if (row != null && !row.Received) ids.Add(row.OrderItemId);
            }

            if (ids.Count == 0)
            {
                MessageBox.Show("The selected item(s) are already completed.",
                    "Complete Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Mark " + ids.Count + (ids.Count == 1 ? " item" : " items") + " as completed (picked up)?\n\n" +
                "This cannot be undone.",
                "Complete Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = OpenConnection())
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    DateTime now = DateTime.Now;

                    foreach (int id in ids)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(
                            @"UPDATE customer_order_items
                              SET is_received = 1, received_at = @t
                              WHERE order_item_id = @id AND is_received = 0", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@t", now);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Close out any order whose products have all been received.
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"UPDATE customer_orders o
                          SET o.is_completed = 1, o.completed_at = @t
                          WHERE o.is_completed = 0
                            AND NOT EXISTS (SELECT 1 FROM customer_order_items i
                                            WHERE i.order_id = o.order_id AND i.is_received = 0)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@t", now);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                }

                LoadAdminData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not complete the order: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= Loading data from the database =================

        private void LoadAdminData()
        {
            TriggerRestockNotifications(); // Automatically sync pending notifications for restocked products
            LoadProducts();
            LoadOrders();
            LoadDashboardExtras();
        }

        // Flips PENDING restock notifications to SENT for any product that currently has stock
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

        // Status of the whole transaction, from how many of its products were received.
        private static string TransactionStatus(int itemCount, int receivedCount)
        {
            if (receivedCount >= itemCount) return "Completed";
            if (receivedCount == 0) return "Pending Pickup";
            return "Partially Received (" + receivedCount + " of " + itemCount + ")";
        }

        // ---- Products: grid + the four stock counters (Product Management and Dashboard) ----
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

            // Product Management panel counters
            TP_Counter.Text = productRows.Count.ToString();
            IS_Counter.Text = inStock.ToString();
            LS_Counter.Text = lowStock.ToString();
            OOS_Counter.Text = outOfStock.ToString();

            // Dashboard counters
            ADTO_Counter.Text = productRows.Count.ToString();
            ADIS_Counter.Text = inStock.ToString();
            ADLS_Counter.Text = lowStock.ToString();
            ADOOS_Counter.Text = outOfStock.ToString();

            FillProductGrid();
        }

        // Search: matches any column (ID, name, category, description, price, quantity, status).
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

        // ---- Orders: grid (one row per product) + the three order counters ----
        private void LoadOrders()
        {
            orderRows.Clear();
            int totalOrders = 0, completedOrders = 0;

            try
            {
                using (MySqlConnection conn = OpenConnection())
                {
                    // Student names come from the users table, looked up by ID number.
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
                        @"SELECT o.order_id, o.user_key, o.placed_at, o.receipt_file,
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

                            orderRows.Add(new OrderRow
                            {
                                OrderItemId = Convert.ToInt32(r["order_item_id"]),
                                OrderId = Convert.ToInt32(r["order_id"]),
                                Received = received,
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
                                    TransactionStatus(itemCount, receivedCount)
                                }
                            });
                        }
                    }

                    // An order is completed once all of its products have been received.
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT COUNT(*), COALESCE(SUM(is_completed), 0) FROM customer_orders", conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            totalOrders = Convert.ToInt32(r[0]);
                            completedOrders = Convert.ToInt32(r[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the orders: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int pendingOrders = totalOrders - completedOrders;

            // Order Management panel counters
            OMTO_Counter.Text = totalOrders.ToString();
            OMPP_Counter.Text = pendingOrders.ToString();
            OMOC_Counter.Text = completedOrders.ToString();

            // Dashboard counters
            TO_Counter.Text = totalOrders.ToString();
            PP_Counter.Text = pendingOrders.ToString();
            OC_Counter.Text = completedOrders.ToString();

            FillOrderGrid();
        }

        // Search: matches any column (order no., student, product, date, status, ...).
        private void FillOrderGrid()
        {
            string q = (OMSearch_Input.Text ?? "").Trim().ToLower();

            dataGridView1.Rows.Clear();
            foreach (OrderRow row in orderRows)
            {
                if (q.Length == 0 || row.Cells.Any(c => c.ToString().ToLower().Contains(q)))
                {
                    int index = dataGridView1.Rows.Add(row.Cells);
                    dataGridView1.Rows[index].Tag = row;   // Complete reads the item id from here
                }
            }
        }

        // ---- Dashboard: Recent Updates and Highest-Demand Products ----
        private void LoadDashboardExtras()
        {
            Label[] updateNames = { P1, P2, P3 };
            Label[] updateDates = { PD1, PD2, PD3 };
            Label[] demandNames = { HDP_P1, HDP_P2, HDP_P3, HDP_P4, HDP_P5, HDP_P6, HDP_P7 };
            Label[] demandCounts = { TR1_Counter, TR2_Counter, TR3_Counter, TR4_Counter, TR5_Counter, TR6_Counter, TR7_Counter };

            // Clear the sample text from the designer first.
            foreach (Label l in updateNames.Concat(updateDates).Concat(demandNames).Concat(demandCounts))
                l.Text = "";

            try
            {
                using (MySqlConnection conn = OpenConnection())
                {
                    // The three most recently changed products.
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

                    // The seven most ordered products (total units ordered by students).
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
    }
}