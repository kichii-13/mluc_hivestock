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
    public partial class PM_CreateProduct : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        public PM_CreateProduct()
        {
            InitializeComponent();

            // The up/down boxes default to a maximum of 100 and no decimals.
            CPPrice_UpDown.Maximum = 100000;
            CPPrice_UpDown.DecimalPlaces = 2;
            CPQuantity_UpDown.Maximum = 100000;

            // Suggest the next free Product ID (it can still be typed over).
            int nextId = GetNextProductId();
            if (nextId > 0) CPProductID_TextBox.Text = nextId.ToString();
        }

        private int GetNextProductId()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT COALESCE(MAX(product_id), 0) + 1 FROM product", conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;   // leave the box empty; it is worked out again when you press CREATE
            }
        }

        private void CPCancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CPCreate_Button_Click(object sender, EventArgs e)
        {
            string name = CPProductName_TextBox.Text.Trim();
            string description = CPDescription_TextBox.Text.Trim();
            decimal price = CPPrice_UpDown.Value;
            int quantity = (int)CPQuantity_UpDown.Value;

            // Dropdown positions: Category 0 = "Choose Category", then Books 1, ID Lace 2, Uniform 3
            // (the same ids the catalog uses). Status 0 = "Select Status".
            int categoryId = CPCategory_Dropdown.SelectedIndex;
            int statusIndex = CPStatus_Dropdown.SelectedIndex;

            if (name.Length == 0)
            {
                ShowWarning("Please enter the product name.");
                return;
            }
            if (categoryId < 1)
            {
                ShowWarning("Please choose a category.");
                return;
            }
            if (description.Length == 0)
            {
                ShowWarning("Please enter a description.");
                return;
            }
            if (price <= 0)
            {
                ShowWarning("The price must be more than zero.");
                return;
            }
            if (statusIndex < 1)
            {
                ShowWarning("Please choose a stock status.");
                return;
            }

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

                    // Product ID: use what was typed, or work out the next free one.
                    int productId;
                    string idText = CPProductID_TextBox.Text.Trim();
                    if (idText.Length == 0)
                    {
                        productId = GetNextProductId();
                        if (productId < 1)
                        {
                            ShowWarning("Could not work out a Product ID. Please type one.");
                            return;
                        }
                    }
                    else if (!int.TryParse(idText, out productId) || productId < 1)
                    {
                        ShowWarning("Product ID must be a whole number greater than 0.");
                        return;
                    }

                    // No duplicate ID or name.
                    using (MySqlCommand check = new MySqlCommand(
                        "SELECT COUNT(*) FROM product WHERE product_id = @id OR product_name = @name", conn))
                    {
                        check.Parameters.AddWithValue("@id", productId);
                        check.Parameters.AddWithValue("@name", name);

                        if (Convert.ToInt64(check.ExecuteScalar()) > 0)
                        {
                            ShowWarning("A product with this Product ID or name already exists.");
                            return;
                        }
                    }

                    using (MySqlCommand insert = new MySqlCommand(
                        @"INSERT INTO product
                            (product_id, product_name, description, stock_status, price, category_id, product_img, stock_qty)
                          VALUES (@id, @name, @desc, @status, @price, @cat, '', @qty)", conn))
                    {
                        insert.Parameters.AddWithValue("@id", productId);
                        insert.Parameters.AddWithValue("@name", name);
                        insert.Parameters.AddWithValue("@desc", description);
                        insert.Parameters.AddWithValue("@status", status);
                        insert.Parameters.AddWithValue("@price", price);
                        insert.Parameters.AddWithValue("@cat", categoryId);
                        insert.Parameters.AddWithValue("@qty", quantity);
                        insert.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product \"" + name + "\" was added.", "HiveStock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;   // tells the admin window to refresh
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add the product: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}