using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Configuration;
using System.Text.RegularExpressions;
using MySqlConnector;

namespace LogIn_HiveStock
{
    public partial class Profile : Form
    {
        private Panel ordersPanel;

        private static readonly Color BrandGreen = Color.FromArgb(18, 77, 28);
        private static readonly Color BrandGold = Color.FromArgb(228, 176, 40);
        private static readonly Color RowFill = Color.FromArgb(235, 237, 227);
        private static readonly Color CheckGray = Color.FromArgb(125, 137, 149);
        private const int RowHeight = 63;
        private const int RowSpacing = 6;
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        // One entry per pending product, so the selection can be read back.
        private class PendingRow
        {
            public int OrderItemId;
            public Guna2CheckBox Check;
        }

        private readonly List<PendingRow> pendingRows = new List<PendingRow>();
        private Guna2CheckBox selectAllCheck;
        private Guna2Button receiveSelectedButton;
        private bool syncingChecks;

        public Profile()
        {
            InitializeComponent();

            ShowUserDetails();
            BuildOrdersPanel();
        }

        // ---- Name and ID ----
        private void ShowUserDetails()
        {
            if (UserSession.IsLoggedIn)
            {
                Name_Label.Text = UserSession.FullName.ToUpper();
                IDNumber_Label.Text = UserSession.IdNumber;

                FirstName_TextBox.Text = UserSession.FirstName;
                LastName_TextBox.Text = UserSession.LastName;
                IDNum_TextBox.Text = UserSession.IdNumber;
                ContactNumber_TextBox.Text = UserSession.Phone;
                Email_TextBox.Text = UserSession.Email;
            }
            else
            {
                Name_Label.Text = "GUEST";
                IDNumber_Label.Text = "Not logged in";
            }
        }

        // ---- Scrolling area for the orders ----
        private void BuildOrdersPanel()
        {
            // Remove the sample rows from the designer; real orders replace them.
            Control[] sampleRows = { PO1_Panel, PO2_Panel, PO3_Panel, C01_Panel, CO2_Panel };
            foreach (Control sample in sampleRows)
                this.Controls.Remove(sample);

            int top = Profile_Panel.Bottom - 1;

            ordersPanel = new Panel();
            ordersPanel.AutoScroll = true;
            ordersPanel.Location = new Point(0, top);
            ordersPanel.Size = new Size(ProfileInfo_Panel.Left, ClientSize.Height - top);
            ordersPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            this.Controls.Add(ordersPanel);

            // Move the two section headings into the scrollable area.
            ordersPanel.Controls.Add(PendingOrders_Label);
            ordersPanel.Controls.Add(CompletedOrders_Label);
        }

        // Rebuilds the Pending and Completed lists from the database.
        private void RefreshOrders()
        {
            if (ordersPanel == null)
                BuildOrdersPanel();

            ordersPanel.SuspendLayout();

            // Remove the old rows and toolbar but keep the two headings. Do not Dispose them:
            // the product pictures are shared with the cart and order records.
            for (int i = ordersPanel.Controls.Count - 1; i >= 0; i--)
            {
                Control c = ordersPanel.Controls[i];
                if (c == PendingOrders_Label || c == CompletedOrders_Label) continue;
                ordersPanel.Controls.RemoveAt(i);
            }
            ordersPanel.AutoScrollPosition = new Point(0, 0);

            pendingRows.Clear();
            selectAllCheck = null;
            receiveSelectedButton = null;

            string userKey = UserSession.OrderKey;

            int y = 24;
            y = AddOrderSection(PendingOrders_Label, OrderManager.GetOrders(userKey, false), y,
                                "Paid", "No pending orders.", true);
            y = AddOrderSection(CompletedOrders_Label, OrderManager.GetOrders(userKey, true), y,
                                "Completed", "No completed orders yet.", false);

            ordersPanel.AutoScrollMinSize = new Size(0, y);
            ordersPanel.ResumeLayout();
        }

        // ---- Sections and rows ----
        // Lays out one heading (plus the selection toolbar for pending items) followed by one row
        // per product; returns the next free Y.
        private int AddOrderSection(Label heading, List<OrderRecord> orders, int y,
                                    string statusText, string emptyText, bool pending)
        {
            heading.Location = new Point(25, y);
            y += heading.Height + 8;

            int rowCount = orders.Sum(o => o.Lines.Count);

            if (pending && rowCount > 0)
                y = AddPendingToolbar(y);

            foreach (OrderRecord order in orders)
            {
                foreach (OrderLine line in order.Lines)
                {
                    ordersPanel.Controls.Add(CreateOrderRow(order, line, y, statusText));
                    y += RowHeight + RowSpacing;
                }
            }

            if (rowCount == 0)
            {
                Label empty = new Label();
                empty.Text = emptyText;
                empty.Font = new Font("Malgun Gothic", 9.75F);
                empty.ForeColor = Color.Gray;
                empty.BackColor = Color.Transparent;
                empty.Location = new Point(60, y);
                empty.Size = new Size(515, 30);
                empty.TextAlign = ContentAlignment.MiddleLeft;
                ordersPanel.Controls.Add(empty);
                y += 40;
            }

            return y + 20;
        }

        // "Select all" checkbox and the "Mark Selected as Received" button above the pending rows.
        private int AddPendingToolbar(int y)
        {
            selectAllCheck = new Guna2CheckBox();
            selectAllCheck.Text = "Select all";
            selectAllCheck.AutoSize = true;
            selectAllCheck.Font = new Font("Malgun Gothic", 9F);
            selectAllCheck.BackColor = Color.Transparent;
            selectAllCheck.Location = new Point(60, y + 6);
            StyleCheck(selectAllCheck);
            selectAllCheck.CheckedChanged += SelectAll_CheckedChanged;

            receiveSelectedButton = new Guna2Button();
            receiveSelectedButton.Text = "Mark Selected as Received";
            receiveSelectedButton.Font = new Font("Malgun Gothic", 8.25F, FontStyle.Bold);
            receiveSelectedButton.ForeColor = Color.White;
            receiveSelectedButton.FillColor = BrandGreen;
            receiveSelectedButton.BorderRadius = 6;
            receiveSelectedButton.Cursor = Cursors.Hand;
            receiveSelectedButton.Size = new Size(210, 30);
            receiveSelectedButton.Location = new Point(365, y);
            receiveSelectedButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            receiveSelectedButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            receiveSelectedButton.Enabled = false;
            // BeginInvoke: the list is rebuilt, which removes this button, so wait until the click finishes.
            receiveSelectedButton.Click += (s, e) => BeginInvoke(new Action(MarkSelectedAsReceived));

            ordersPanel.Controls.Add(selectAllCheck);
            ordersPanel.Controls.Add(receiveSelectedButton);

            return y + 30 + 8;
        }

        private static void StyleCheck(Guna2CheckBox check)
        {
            check.CheckedState.BorderColor = BrandGold;
            check.CheckedState.BorderRadius = 3;
            check.CheckedState.BorderThickness = 0;
            check.CheckedState.FillColor = BrandGold;
            check.UncheckedState.BorderColor = CheckGray;
            check.UncheckedState.BorderRadius = 3;
            check.UncheckedState.BorderThickness = 0;
            check.UncheckedState.FillColor = CheckGray;
        }

        private Guna2Panel CreateOrderRow(OrderRecord order, OrderLine line, int y, string statusText)
        {
            bool pending = !line.IsReceived;
            int shift = pending ? 30 : 0;   // pending rows make room for the checkbox

            Guna2Panel panel = new Guna2Panel();
            panel.BackColor = Color.Transparent;
            panel.BorderColor = BrandGreen;
            panel.BorderRadius = 10;
            panel.BorderThickness = 1;
            panel.FillColor = RowFill;
            panel.Location = new Point(60, y);
            panel.Size = new Size(515, RowHeight);

            Guna2PictureBox picture = new Guna2PictureBox();
            picture.BackColor = Color.Transparent;
            picture.BorderRadius = 10;
            picture.FillColor = Color.Transparent;
            picture.Image = line.Image;
            picture.Location = new Point(16 + shift, 7);
            picture.Size = new Size(80, 50);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.TabStop = false;
            picture.UseTransparentBackground = true;

            int textWidth = pending ? 250 : 298;

            Label title = new Label();
            title.Font = new Font("Malgun Gothic", 9.75F, FontStyle.Bold);
            title.Location = new Point(102 + shift, 8);
            title.Size = new Size(textWidth, 24);
            title.Text = $"{line.Name}  x{line.Quantity}";
            title.TextAlign = ContentAlignment.MiddleLeft;
            title.AutoEllipsis = true;

            string dateText = line.IsReceived && line.ReceivedAt.HasValue
                ? "Received " + line.ReceivedAt.Value.ToString("dd MMM yyyy, h:mm tt")
                : "Ordered " + order.PlacedAt.ToString("dd MMM yyyy");

            Label detail = new Label();
            detail.Font = new Font("Malgun Gothic", 8.25F);
            detail.ForeColor = Color.DimGray;
            detail.Location = new Point(102 + shift, 32);
            detail.Size = new Size(textWidth, 22);
            detail.Text = $"{order.OrderNumber}  \u2022  {dateText}  \u2022  \u20B1{line.Subtotal:N2}";
            detail.TextAlign = ContentAlignment.MiddleLeft;
            detail.AutoEllipsis = true;

            Label status = new Label();
            status.Font = new Font("Malgun Gothic", 9.75F, FontStyle.Bold);
            status.ForeColor = BrandGreen;
            status.Location = new Point(405, 22);
            status.Size = new Size(100, 19);
            status.Text = statusText;
            status.TextAlign = ContentAlignment.MiddleRight;

            if (pending)
            {
                // Checkbox used by "Select all" / "Mark Selected as Received".
                Guna2CheckBox check = new Guna2CheckBox();
                check.AutoSize = true;
                check.Location = new Point(14, 25);
                check.Size = new Size(15, 14);
                StyleCheck(check);
                check.CheckedChanged += (s, e) => OnRowCheckChanged();
                pendingRows.Add(new PendingRow { OrderItemId = line.OrderItemId, Check = check });
                panel.Controls.Add(check);

                // Button for this one product only.
                status.Location = new Point(405, 6);

                int orderItemId = line.OrderItemId;
                string itemName = line.Name;

                Guna2Button receive = new Guna2Button();
                receive.Text = "Mark as Received";
                receive.Font = new Font("Malgun Gothic", 8.25F, FontStyle.Bold);
                receive.ForeColor = Color.White;
                receive.FillColor = BrandGreen;
                receive.BorderRadius = 6;
                receive.Location = new Point(385, 30);
                receive.Size = new Size(120, 26);
                receive.Cursor = Cursors.Hand;

                // BeginInvoke: the list is rebuilt, which removes this button, so wait until the click finishes.
                receive.Click += (s, e) => BeginInvoke(new Action(() => MarkOneAsReceived(orderItemId, itemName)));

                panel.Controls.Add(receive);
            }

            panel.Controls.Add(status);
            panel.Controls.Add(detail);
            panel.Controls.Add(title);
            panel.Controls.Add(picture);
            return panel;
        }

        // ---- Selection ----
        private void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (syncingChecks) return;

            syncingChecks = true;
            foreach (PendingRow row in pendingRows)
                row.Check.Checked = selectAllCheck.Checked;
            syncingChecks = false;

            UpdateSelectionState();
        }

        private void OnRowCheckChanged()
        {
            if (syncingChecks) return;

            syncingChecks = true;
            selectAllCheck.Checked = pendingRows.Count > 0 && pendingRows.All(r => r.Check.Checked);
            syncingChecks = false;

            UpdateSelectionState();
        }

        private void UpdateSelectionState()
        {
            int selected = pendingRows.Count(r => r.Check.Checked);
            receiveSelectedButton.Enabled = selected > 0;
            receiveSelectedButton.Text = selected > 0
                ? $"Mark Selected as Received ({selected})"
                : "Mark Selected as Received";
        }

        // ---- Mark as Received ----
        // One product.
        private void MarkOneAsReceived(int orderItemId, string itemName)
        {
            DialogResult answer = MessageBox.Show(
                "Confirm that you have received \"" + itemName + "\"?\n\n" +
                "It will move to Completed Orders and this cannot be undone.",
                "Mark as Received", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            if (OrderManager.MarkItemsReceived(new[] { orderItemId }, UserSession.OrderKey) > 0)
                RefreshOrders();
        }

        // Every ticked product.
        private void MarkSelectedAsReceived()
        {
            List<int> ids = pendingRows.Where(r => r.Check.Checked)
                                       .Select(r => r.OrderItemId)
                                       .ToList();
            if (ids.Count == 0) return;

            string question = ids.Count == 1
                ? "Mark the selected item as received?"
                : $"Mark {ids.Count} selected items as received?";

            DialogResult answer = MessageBox.Show(
                question + "\n\nThey will move to Completed Orders and this cannot be undone.",
                "Mark as Received", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            if (OrderManager.MarkItemsReceived(ids, UserSession.OrderKey) > 0)
                RefreshOrders();
        }

        // ---- Existing handlers (kept: the designer connects them) ----
        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Profile_Back_Button_Click(object sender, EventArgs e)
        {
            UserView_ProductCatalog userView = new UserView_ProductCatalog();
            userView.Show();
            this.Close();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            RefreshOrders();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        // The cart is saved per user in the database, so logging out does not touch it.
        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            UserSession.SignOut();

            LogIn_Register logIn = new LogIn_Register();
            logIn.Show();
            this.Close();
        }

        private void EditDetails_Button_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("Please log in to edit your details.", "HiveStock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowUserDetails();                 // fill the boxes with the saved details
            EditDetails_Panel.Visible = true;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            ShowUserDetails();                 // throw away anything typed
            EditDetails_Panel.Visible = false;
        }

        private void EditDone_Button_Click(object sender, EventArgs e)
        {
            string firstName = FirstName_TextBox.Text.Trim();
            string lastName = LastName_TextBox.Text.Trim();
            string idInput = IDNum_TextBox.Text.Trim();
            string phone = ContactNumber_TextBox.Text.Trim();
            string email = Email_TextBox.Text.Trim();

            // Nothing may be empty.
            if (firstName.Length == 0 || lastName.Length == 0 || idInput.Length == 0 ||
                phone.Length == 0 || email.Length == 0)
            {
                ShowWarning("Please fill in all the fields.");
                return;
            }

            // Names: letters, spaces, apostrophes and hyphens only (same rule as registration).
            Regex nameRegex = new Regex(@"^[a-zA-Z\s'-]+$");
            if (!nameRegex.IsMatch(firstName) || !nameRegex.IsMatch(lastName))
            {
                ShowWarning("Names cannot contain numbers or special characters.");
                return;
            }

            // ID number: exactly 8 digits, saved as xxx-xxxx-x.
            string cleanId = Regex.Replace(idInput, @"[\s-]", "");
            if (!Regex.IsMatch(cleanId, @"^[0-9]{8}$"))
            {
                ShowWarning("ID Number must be exactly 8 digits (e.g., 12345678).");
                return;
            }
            string newId = string.Format("{0}-{1}-{2}",
                cleanId.Substring(0, 3), cleanId.Substring(3, 4), cleanId.Substring(7, 1));

            // Phone: exactly 11 digits (same rule as registration).
            if (!Regex.IsMatch(phone, @"^[0-9]{11}$"))
            {
                ShowWarning("Contact number must be exactly 11 digits.");
                return;
            }

            // Email: something@something.something
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowWarning("Please enter a valid email address.");
                return;
            }

            // Nothing changed? Just close the panel.
            if (firstName == UserSession.FirstName && lastName == UserSession.LastName &&
                newId == UserSession.IdNumber && phone == UserSession.Phone &&
                email == UserSession.Email)
            {
                MessageBox.Show("No changes to save.", "HiveStock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                EditDetails_Panel.Visible = false;
                return;
            }

            string oldId = UserSession.IdNumber;
            if (!SaveProfileChanges(oldId, newId, firstName, lastName, email, phone))
                return;   // a message was already shown; the panel stays open so nothing typed is lost

            // The database is updated, so update the session and the screen too.
            UserSession.UpdateDetails(newId, firstName, lastName, email, phone);
            ShowUserDetails();
            RefreshOrders();                  // orders are looked up by ID number, so reload them
            EditDetails_Panel.Visible = false;

            MessageBox.Show("Your details were updated.", "HiveStock",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Updates the users table (and moves the cart and orders if the ID number changed).
        // All-or-nothing: returns false and changes nothing if anything goes wrong.
        private bool SaveProfileChanges(string oldId, string newId, string firstName,
                                        string lastName, string email, string phone)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // The new ID number and email must not belong to another account.
                    using (MySqlCommand check = new MySqlCommand(
                        @"SELECT COUNT(*) FROM users
                  WHERE (id_number = @newId OR email_address = @email) AND id_number <> @oldId", conn))
                    {
                        check.Parameters.AddWithValue("@newId", newId);
                        check.Parameters.AddWithValue("@email", email);
                        check.Parameters.AddWithValue("@oldId", oldId);

                        if (Convert.ToInt64(check.ExecuteScalar()) > 0)
                        {
                            ShowWarning("Another account already uses this ID Number or Email.");
                            return false;
                        }
                    }

                    using (MySqlTransaction tx = conn.BeginTransaction())
                    {
                        using (MySqlCommand update = new MySqlCommand(
                            @"UPDATE users
                      SET first_name = @first, last_name = @last, id_number = @newId,
                          email_address = @email, phone_number = @phone
                      WHERE id_number = @oldId", conn, tx))
                        {
                            update.Parameters.AddWithValue("@first", firstName);
                            update.Parameters.AddWithValue("@last", lastName);
                            update.Parameters.AddWithValue("@newId", newId);
                            update.Parameters.AddWithValue("@email", email);
                            update.Parameters.AddWithValue("@phone", phone);
                            update.Parameters.AddWithValue("@oldId", oldId);

                            if (update.ExecuteNonQuery() == 0)
                            {
                                tx.Rollback();
                                MessageBox.Show("Your account could not be found, so nothing was changed.",
                                    "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }

                        // The cart and orders are tied to the ID number, so they follow it.
                        if (newId != oldId)
                        {
                            foreach (string table in new[] { "cart_items", "customer_orders" })
                            {
                                using (MySqlCommand move = new MySqlCommand(
                                    "UPDATE " + table + " SET user_key = @newId WHERE user_key = @oldId", conn, tx))
                                {
                                    move.Parameters.AddWithValue("@newId", newId);
                                    move.Parameters.AddWithValue("@oldId", oldId);
                                    move.ExecuteNonQuery();
                                }
                            }
                        }

                        tx.Commit();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save your details: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}