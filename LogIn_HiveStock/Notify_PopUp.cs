using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySqlConnector;

namespace LogIn_HiveStock
{
    public partial class Notify_PopUp : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        private int productId = 0;

        public Notify_PopUp()
        {
            InitializeComponent();
            NotifyMe_Button.Enabled = ReceiveAlert_Check.Checked;
        }

        // Tells the popup which product the student wants to be alerted about.
        public void SetProduct(int productId, string name, Image image)
        {
            this.productId = productId;
            Product_Label.Text = name;

            if (image != null)
            {
                Picture.Image = image;
                Picture.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void ATCPU_Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReceiveAlert_Check_CheckedChanged(object sender, EventArgs e)
        {
            NotifyMe_Button.Enabled = ReceiveAlert_Check.Checked;
        }

        // The Notify Me button (the designer connects it to this name).
        private void ConfirmBuy_Button_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("Please log in to get restock alerts.", "HiveStock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (productId == 0)
            {
                MessageBox.Show("No product was selected.", "HiveStock",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // The table uses the numeric user id of the account.
                    int userId;
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT user_id FROM users WHERE id_number = @id OR username = @id LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", UserSession.IdNumber);
                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Your account could not be found.", "HiveStock",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        userId = Convert.ToInt32(result);
                    }

                    // Already waiting for this product?
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT status FROM notification_subscription WHERE user_id = @u AND product_id = @p", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", userId);
                        cmd.Parameters.AddWithValue("@p", productId);
                        object status = cmd.ExecuteScalar();

                        if (status != null && status.ToString() == "PENDING")
                        {
                            MessageBox.Show("You are already on the list. We will alert you when this product is restocked.",
                                "HiveStock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            return;
                        }
                    }

                    // New request, or a new request after an earlier alert was already sent.
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"INSERT INTO notification_subscription (user_id, product_id, status, created_at, read_at, notified_at)
                          VALUES (@u, @p, 'PENDING', NOW(), NULL, NULL)
                          ON DUPLICATE KEY UPDATE status = 'PENDING', created_at = NOW(),
                                                  read_at = NULL, notified_at = NULL", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", userId);
                        cmd.Parameters.AddWithValue("@p", productId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Done! You will be alerted when " + Product_Label.Text + " is back in stock.",
                    "HiveStock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save your request: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
