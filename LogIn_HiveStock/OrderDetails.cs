using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MySqlConnector;

namespace LogIn_HiveStock
{
    // Shows one order: who ordered, the products, the transaction status and the payment receipt.
    public class OrderDetails : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        private readonly int orderId;

        private Label orderNoLabel;
        private Label statusLabel;
        private Label studentLabel;
        private Label dateLabel;
        private Label totalLabel;
        private DataGridView grid;
        private PictureBox receiptBox;
        private Label receiptNameLabel;

        public OrderDetails(int orderId)
        {
            this.orderId = orderId;
            BuildLayout();
            LoadOrder();
        }

        private void BuildLayout()
        {
            Color green = Color.FromArgb(18, 77, 28);
            Color gold = Color.FromArgb(228, 176, 40);

            this.Text = "Order Details";
            this.ClientSize = new Size(940, 560);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(235, 237, 227);
            this.Font = new Font("Malgun Gothic", 9F);

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 64;
            header.BackColor = green;

            orderNoLabel = new Label();
            orderNoLabel.AutoSize = true;
            orderNoLabel.ForeColor = Color.White;
            orderNoLabel.Font = new Font("Malgun Gothic", 16F, FontStyle.Bold);
            orderNoLabel.Location = new Point(20, 14);
            header.Controls.Add(orderNoLabel);

            statusLabel = new Label();
            statusLabel.AutoSize = false;
            statusLabel.Size = new Size(260, 30);
            statusLabel.Location = new Point(660, 17);
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold);
            statusLabel.BackColor = gold;
            statusLabel.ForeColor = Color.Black;
            header.Controls.Add(statusLabel);

            studentLabel = new Label();
            studentLabel.AutoSize = false;
            studentLabel.Size = new Size(540, 24);
            studentLabel.Location = new Point(20, 80);
            studentLabel.Font = new Font("Malgun Gothic", 10.5F, FontStyle.Bold);

            dateLabel = new Label();
            dateLabel.AutoSize = false;
            dateLabel.Size = new Size(540, 22);
            dateLabel.Location = new Point(20, 108);
            dateLabel.ForeColor = Color.DimGray;

            grid = new DataGridView();
            grid.Location = new Point(20, 142);
            grid.Size = new Size(540, 300);
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersVisible = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = green;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Malgun Gothic", 8.25F, FontStyle.Bold);
            grid.DefaultCellStyle.Font = new Font("Malgun Gothic", 8.25F);

            DataGridViewTextBoxColumn product = new DataGridViewTextBoxColumn();
            product.HeaderText = "Product";
            product.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns.Add(product);
            grid.Columns.Add(MakeColumn("Qty", 40));
            grid.Columns.Add(MakeColumn("Unit Price", 75));
            grid.Columns.Add(MakeColumn("Subtotal", 80));
            grid.Columns.Add(MakeColumn("Item Status", 75));
            grid.Columns.Add(MakeColumn("Received", 125));

            totalLabel = new Label();
            totalLabel.AutoSize = false;
            totalLabel.Size = new Size(540, 26);
            totalLabel.Location = new Point(20, 450);
            totalLabel.Font = new Font("Malgun Gothic", 11F, FontStyle.Bold);
            totalLabel.ForeColor = green;

            Button close = new Button();
            close.Text = "CLOSE";
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
            close.BackColor = green;
            close.ForeColor = Color.White;
            close.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold);
            close.Cursor = Cursors.Hand;
            close.Size = new Size(120, 34);
            close.Location = new Point(20, 495);
            close.Click += (s, e) => this.Close();

            Label receiptCaption = new Label();
            receiptCaption.AutoSize = true;
            receiptCaption.Font = new Font("Malgun Gothic", 10.5F, FontStyle.Bold);
            receiptCaption.Text = "Payment receipt / QR";
            receiptCaption.Location = new Point(590, 80);

            receiptBox = new PictureBox();
            receiptBox.Location = new Point(590, 108);
            receiptBox.Size = new Size(330, 400);
            receiptBox.SizeMode = PictureBoxSizeMode.Zoom;
            receiptBox.BackColor = Color.White;
            receiptBox.BorderStyle = BorderStyle.FixedSingle;
            receiptBox.Cursor = Cursors.Hand;
            receiptBox.DoubleClick += ReceiptBox_DoubleClick;

            receiptNameLabel = new Label();
            receiptNameLabel.AutoSize = false;
            receiptNameLabel.AutoEllipsis = true;
            receiptNameLabel.Size = new Size(330, 36);
            receiptNameLabel.Location = new Point(590, 512);
            receiptNameLabel.ForeColor = Color.DimGray;
            receiptNameLabel.Font = new Font("Malgun Gothic", 8.25F);

            this.Controls.Add(header);
            this.Controls.Add(studentLabel);
            this.Controls.Add(dateLabel);
            this.Controls.Add(grid);
            this.Controls.Add(totalLabel);
            this.Controls.Add(close);
            this.Controls.Add(receiptCaption);
            this.Controls.Add(receiptBox);
            this.Controls.Add(receiptNameLabel);
        }

        private static DataGridViewTextBoxColumn MakeColumn(string header, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = header;
            col.Width = width;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            return col;
        }

        private void LoadOrder()
        {
            string userKey = "";
            string receiptFile = "";
            DateTime placedAt = DateTime.MinValue;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    bool found = false;
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT user_key, placed_at, receipt_file FROM customer_orders WHERE order_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                found = true;
                                userKey = r["user_key"].ToString().Trim();
                                placedAt = Convert.ToDateTime(r["placed_at"]);
                                receiptFile = r["receipt_file"] == DBNull.Value ? "" : r["receipt_file"].ToString();
                            }
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("This order could not be found.", "Order Details",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string studentName = "(unknown)";
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT first_name, last_name FROM users WHERE id_number = @u", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", userKey);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                                studentName = (r["first_name"].ToString().Trim() + " " +
                                               r["last_name"].ToString().Trim()).Trim();
                        }
                    }

                    int itemCount = 0, receivedCount = 0;
                    decimal total = 0;

                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT product_name, quantity, unit_price, is_received, received_at
                          FROM customer_order_items WHERE order_id = @id ORDER BY order_item_id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                int qty = Convert.ToInt32(r["quantity"]);
                                decimal price = Convert.ToDecimal(r["unit_price"]);
                                bool received = Convert.ToInt32(r["is_received"]) != 0;

                                itemCount++;
                                if (received) receivedCount++;
                                total += price * qty;

                                grid.Rows.Add(
                                    r["product_name"].ToString(),
                                    qty,
                                    "\u20B1" + price.ToString("N2"),
                                    "\u20B1" + (price * qty).ToString("N2"),
                                    received ? "Received" : "Pending",
                                    r["received_at"] == DBNull.Value ? "" :
                                        Convert.ToDateTime(r["received_at"])
                                            .ToString("dd MMM yyyy h:mm tt", CultureInfo.InvariantCulture));
                            }
                        }
                    }

                    // Header: order number and the status of the whole transaction.
                    orderNoLabel.Text = "Order HS-" + orderId.ToString("D4");
                    studentLabel.Text = "Student: " + studentName + "   (ID " + userKey + ")";
                    dateLabel.Text = "Ordered on " + placedAt.ToString("dd MMM yyyy, h:mm tt", CultureInfo.InvariantCulture);
                    totalLabel.Text = "Order total:  \u20B1" + total.ToString("N2");

                    if (itemCount > 0 && receivedCount >= itemCount)
                    {
                        statusLabel.Text = "Transaction: Completed";
                        statusLabel.BackColor = Color.White;
                        statusLabel.ForeColor = Color.FromArgb(18, 77, 28);
                    }
                    else if (receivedCount == 0)
                    {
                        statusLabel.Text = "Transaction: Pending Pickup";
                    }
                    else
                    {
                        statusLabel.Text = "Partially Received (" + receivedCount + " of " + itemCount + ")";
                    }
                }

                // Payment receipt / QR picture.
                Image receipt = ProductImages.LoadReceipt(receiptFile);
                receiptBox.Image = receipt;

                if (receipt != null)
                    receiptNameLabel.Text = receiptFile + "\nDouble-click the picture to enlarge it.";
                else if (string.IsNullOrWhiteSpace(receiptFile))
                    receiptNameLabel.Text = "No receipt picture was recorded for this order.";
                else
                    receiptNameLabel.Text = "Receipt file not found: " + receiptFile +
                                            "\n(Orders placed before receipts were saved have no picture.)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the order: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiptBox_DoubleClick(object sender, EventArgs e)
        {
            if (receiptBox.Image == null) return;

            using (Form viewer = new Form())
            {
                viewer.Text = "Payment receipt";
                viewer.StartPosition = FormStartPosition.CenterParent;
                viewer.Size = new Size(760, 820);

                PictureBox big = new PictureBox();
                big.Dock = DockStyle.Fill;
                big.SizeMode = PictureBoxSizeMode.Zoom;
                big.BackColor = Color.Black;
                big.Image = receiptBox.Image;

                viewer.Controls.Add(big);
                viewer.ShowDialog(this);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (receiptBox.Image != null)
            {
                receiptBox.Image.Dispose();
                receiptBox.Image = null;
            }
        }
    }
}