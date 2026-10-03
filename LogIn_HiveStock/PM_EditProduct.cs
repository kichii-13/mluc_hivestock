using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace LogIn_HiveStock
{
    public partial class PM_EditProduct : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        private readonly int startProductId;
        private int loadedProductId = 0;   // the product currently in the boxes (0 = none)

        public PM_EditProduct() : this(0) { }

        public PM_EditProduct(int productId)
        {
            InitializeComponent();
            startProductId = productId;

            EPPrice_UpDown.Maximum = 100000;
            EPPrice_UpDown.DecimalPlaces = 2;
            EPQuantity_UpDown.Maximum = 100000;

            EPProductID_TextBox.KeyDown += EPProductID_TextBox_KeyDown;
            EPProductID_TextBox.Leave += (s, e) => LoadProduct(true);   // quiet check when leaving the box
            this.Shown += (s, e) =>
            {
                if (startProductId > 0)
                {
                    EPProductID_TextBox.Text = startProductId.ToString();
                    LoadProduct(false);
                }
                else
                {
                    EPProductID_TextBox.Focus();
                }
            };
        }

        // Enter = search for the product.
        private void EPProductID_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                LoadProduct(false);
            }
        }

        // Fills the boxes from the database. quiet = no messages when nothing is found.
        private bool LoadProduct(bool quiet)
        {
            int id;
            if (!int.TryParse(EPProductID_TextBox.Text.Trim(), out id) || id < 1)
            {
                if (!quiet) ShowWarning("Enter a valid Product ID, then press Enter.");
                return false;
            }

            if (id == loadedProductId) return true;   // already showing this product

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT product_name, description, price, category_id, stock_qty, stock_status
                          FROM product WHERE product_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                if (!quiet) ShowWarning("No product found with Product ID " + id + ".");
                                ClearFields();
                                return false;
                            }

                            EPProductName_TextBox.Text = r["product_name"].ToString().Trim();
                            EPDescription_TextBox.Text = r["description"].ToString().Trim();

                            decimal price = Convert.ToDecimal(r["price"]);
                            EPPrice_UpDown.Value = Math.Max(EPPrice_UpDown.Minimum, Math.Min(EPPrice_UpDown.Maximum, price));

                            int qty = Convert.ToInt32(r["stock_qty"]);
                            EPQuantity_UpDown.Value = Math.Max(EPQuantity_UpDown.Minimum, Math.Min(EPQuantity_UpDown.Maximum, qty));

                            int cat = Convert.ToInt32(r["category_id"]);
                            EPCategory_Dropdown.SelectedIndex = (cat >= 1 && cat <= 3) ? cat : 0;

                            switch (r["stock_status"].ToString().Trim().ToLower())
                            {
                                case "in stock":
                                case "on stock": EPStatus_Dropdown.SelectedIndex = 1; break;
                                case "low stock": EPStatus_Dropdown.SelectedIndex = 2; break;
                                case "out of stock":
                                case "no stock": EPStatus_Dropdown.SelectedIndex = 3; break;
                                default: EPStatus_Dropdown.SelectedIndex = 0; break;
                            }

                            loadedProductId = id;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!quiet)
                    MessageBox.Show("Could not load the product: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ClearFields()
        {
            loadedProductId = 0;
            EPProductName_TextBox.Clear();
            EPDescription_TextBox.Clear();
            EPPrice_UpDown.Value = EPPrice_UpDown.Minimum;
            EPQuantity_UpDown.Value = EPQuantity_UpDown.Minimum;
            EPCategory_Dropdown.SelectedIndex = 0;
            EPStatus_Dropdown.SelectedIndex = 0;
        }

        private void EPCancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // The green button: saves the changes to the product that was loaded.
        private void EPCreate_Button_Click(object sender, EventArgs e)
        {
            if (loadedProductId == 0)
            {
                ShowWarning("Type a Product ID and press Enter to load the product first.");
                return;
            }

            int typedId;
            if (!int.TryParse(EPProductID_TextBox.Text.Trim(), out typedId) || typedId != loadedProductId)
            {
                ShowWarning("The Product ID was changed. Press Enter to load that product first.");
                return;
            }

            string name = EPProductName_TextBox.Text.Trim();
            string description = EPDescription_TextBox.Text.Trim();
            decimal price = EPPrice_UpDown.Value;
            int quantity = (int)EPQuantity_UpDown.Value;
            int categoryId = EPCategory_Dropdown.SelectedIndex;   // 1 Books, 2 ID Lace, 3 Uniform
            int statusIndex = EPStatus_Dropdown.SelectedIndex;

            if (name.Length == 0) { ShowWarning("Please enter the product name."); return; }
            if (categoryId < 1) { ShowWarning("Please choose a category."); return; }
            if (description.Length == 0) { ShowWarning("Please enter a description."); return; }
            if (price <= 0) { ShowWarning("The price must be more than zero."); return; }
            if (statusIndex < 1) { ShowWarning("Please choose a stock status."); return; }

            // The catalog understands "In Stock", so "On Stock" is saved as "In Stock".
            string status = statusIndex == 1 ? "In Stock" : statusIndex == 2 ? "Low Stock" : "Out of Stock";

            if (status == "Out of Stock" && quantity > 0)
            {
                ShowWarning("An Out of Stock product must have a quantity of 0.");
                return;
            }
            if (status != "Out of Stock" && quantity < 1)
            {
                ShowWarning("An In Stock or Low Stock product needs a quantity of at least 1.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Another product must not already have this name.
                    using (MySqlCommand check = new MySqlCommand(
                        "SELECT COUNT(*) FROM product WHERE product_name = @name AND product_id <> @id", conn))
                    {
                        check.Parameters.AddWithValue("@name", name);
                        check.Parameters.AddWithValue("@id", loadedProductId);

                        if (Convert.ToInt64(check.ExecuteScalar()) > 0)
                        {
                            ShowWarning("Another product already has this name.");
                            return;
                        }
                    }

                    using (MySqlCommand update = new MySqlCommand(
                        @"UPDATE product
                          SET product_name = @name, description = @desc, stock_status = @status,
                              price = @price, category_id = @cat, stock_qty = @qty
                          WHERE product_id = @id", conn))
                    {
                        update.Parameters.AddWithValue("@name", name);
                        update.Parameters.AddWithValue("@desc", description);
                        update.Parameters.AddWithValue("@status", status);
                        update.Parameters.AddWithValue("@price", price);
                        update.Parameters.AddWithValue("@cat", categoryId);
                        update.Parameters.AddWithValue("@qty", quantity);
                        update.Parameters.AddWithValue("@id", loadedProductId);
                        update.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product \"" + name + "\" was updated.", "HiveStock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;   // tells the admin window to refresh
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update the product: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}