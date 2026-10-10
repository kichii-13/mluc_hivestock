using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MySqlConnector;

namespace LogIn_HiveStock
{
    // One order: who ordered, the products, the status and the payment receipt.
    // Admins can verify or reject the receipt here.
    public class OrderDetails : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        private readonly int orderId;
        private readonly bool canVerify;
        private readonly string checkerName;

        // True when the payment was verified or rejected, so the admin window knows to refresh.
        public bool Changed { get; private set; }

        private Label orderNoLabel;
        private Label statusLabel;
        private Label studentLabel;
        private Label dateLabel;
        private Label paymentLabel;
        private Label totalLabel;
        private DataGridView grid;
        private PictureBox receiptBox;
        private Label receiptNameLabel;
        private Button verifyButton;
        private Button rejectButton;

        private string paymentStatus = "";

        public OrderDetails(int orderId, bool canVerify, string checkerName)
        {
            this.orderId = orderId;
            this.canVerify = canVerify;
            this.checkerName = checkerName;
            BuildLayout();
            LoadOrder();
        }

        private void BuildLayout()
        {
            Color green = Color.FromArgb(18, 77, 28);

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
            statusLabel.Size = new Size(280, 30);
            statusLabel.Location = new Point(640, 17);
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Font = new Font("Malgun Gothic", 10F, FontStyle.Bold);
            header.Controls.Add(statusLabel);

            studentLabel = new Label();
            studentLabel.AutoSize = false;
            studentLabel.Size = new Size(540, 24);
            studentLabel.Location = new Point(20, 76);
            studentLabel.Font = new Font("Malgun Gothic", 10.5F, FontStyle.Bold);

            dateLabel = new Label();
            dateLabel.AutoSize = false;
            dateLabel.Size = new Size(540, 22);
            dateLabel.Location = new Point(20, 100);
            dateLabel.ForeColor = Color.DimGray;

            paymentLabel = new Label();
            paymentLabel.AutoSize = false;
            paymentLabel.Size = new Size(540, 22);
            paymentLabel.Location = new Point(20, 122);
            paymentLabel.ForeColor = Color.DimGray;

            grid = new DataGridView();
            grid.Location = new Point(20, 150);
            grid.Size = new Size(540, 290);
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
            totalLabel.Location = new Point(20, 448);
            totalLabel.Font = new Font("Malgun Gothic", 11F, FontStyle.Bold);
            totalLabel.ForeColor = green;

            Button close = MakeButton("CLOSE", green, Color.White, 20, 495, 120);
            close.Click += (s, e) => this.Close();

            verifyButton = MakeButton("VERIFY PAYMENT", Color.FromArgb(46, 125, 50), Color.White, 150, 495, 150);
            verifyButton.Click += VerifyButton_Click;

            rejectButton = MakeButton("REJECT RECEIPT", Color.FromArgb(178, 34, 34), Color.White, 310, 495, 150);
            rejectButton.Click += RejectButton_Click;

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
            this.Controls.Add(paymentLabel);
            this.Controls.Add(grid);
            this.Controls.Add(totalLabel);
            this.Controls.Add(close);
            this.Controls.Add(verifyButton);
            this.Controls.Add(rejectButton);
            this.Controls.Add(receiptCaption);
            this.Controls.Add(receiptBox);
            this.Controls.Add(receiptNameLabel);
        }

        private static Button MakeButton(string text, Color back, Color fore, int x, int y, int width)
        {
            Button b = new Button();
            b.Text = text;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = back;
            b.ForeColor = fore;
            b.Font = new Font("Malgun Gothic", 9.5F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.Size = new Size(width, 34);
            b.Location = new Point(x, y);
            return b;
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
            grid.Rows.Clear();

            string userKey = "";
            string receiptFile = "";
            string checkedBy = "";
            DateTime placedAt = DateTime.MinValue;
            DateTime? checkedAt = null;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    bool found = false;
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT user_key, placed_at, receipt_file, payment_status, payment_checked_by, payment_checked_at
                          FROM customer_orders WHERE order_id = @id", conn))
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
                                paymentStatus = r["payment_status"].ToString();
                                checkedBy = r["payment_checked_by"] == DBNull.Value ? "" : r["payment_checked_by"].ToString();
                                checkedAt = r["payment_checked_at"] == DBNull.Value
                                    ? (DateTime?)null : Convert.ToDateTime(r["payment_checked_at"]);
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

                    orderNoLabel.Text = "Order HS-" + orderId.ToString("D4");
                    studentLabel.Text = "Student: " + studentName + "   (ID " + userKey + ")";
                    dateLabel.Text = "Ordered on " + placedAt.ToString("dd MMM yyyy, h:mm tt", CultureInfo.InvariantCulture);
                    totalLabel.Text = "Order total:  \u20B1" + total.ToString("N2");

                    if (paymentStatus == OrderManager.PaymentVerifying)
                    {
                        paymentLabel.Text = canVerify
                            ? "Check the receipt on the right, then verify or reject it."
                            : "Waiting for an administrator to check the receipt.";
                    }
                    else
                    {
                        string verb = paymentStatus == OrderManager.PaymentPaid ? "verified" : "rejected";
                        paymentLabel.Text = "Receipt " + verb + (checkedBy.Length > 0 ? " by " + checkedBy : "") +
                            (checkedAt.HasValue ? " on " + checkedAt.Value.ToString("dd MMM yyyy, h:mm tt", CultureInfo.InvariantCulture) : "");
                    }

                    ShowStatus(OrderManager.TransactionStatus(paymentStatus, itemCount, receivedCount));
                }

                bool needsCheck = canVerify && paymentStatus == OrderManager.PaymentVerifying;
                verifyButton.Visible = needsCheck;
                rejectButton.Visible = needsCheck;

                Image old = receiptBox.Image;
                Image receipt = ProductImages.LoadReceipt(receiptFile);
                receiptBox.Image = receipt;
                if (old != null) old.Dispose();

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

        private void ShowStatus(string text)
        {
            statusLabel.Text = text;

            if (text == "Completed")
            {
                statusLabel.BackColor = Color.White;
                statusLabel.ForeColor = Color.FromArgb(18, 77, 28);
            }
            else if (text == "Payment Rejected")
            {
                statusLabel.BackColor = Color.FromArgb(178, 34, 34);
                statusLabel.ForeColor = Color.White;
            }
            else if (text == "Verifying Payment")
            {
                statusLabel.BackColor = Color.FromArgb(228, 176, 40);
                statusLabel.ForeColor = Color.Black;
            }
            else
            {
                statusLabel.BackColor = Color.FromArgb(200, 230, 201);
                statusLabel.ForeColor = Color.FromArgb(18, 77, 28);
            }
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Is the receipt valid and the payment received?\n\n" +
                "The order will be marked Paid and can then be handed over to the student.",
                "Verify Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            if (OrderManager.VerifyPayment(orderId, checkerName))
            {
                Changed = true;
                LoadOrder();
            }
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Reject this receipt?\n\n" +
                "The ordered quantities go back into stock, and the student will see the order as Rejected " +
                "and has to order again.",
                "Reject Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes) return;

            if (OrderManager.RejectPayment(orderId, checkerName))
            {
                Changed = true;
                LoadOrder();
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