using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn_HiveStock
{
    public partial class AddToCart_PopUp : Form
    {
        private int productId;
        private decimal unitPrice;
        private int stockLimit = 1;
        private bool canAdd = true;

        public AddToCart_PopUp()
        {
            InitializeComponent();
        }
        public void SetProduct(int id, string name, decimal price, Image image, int maxQty)
        {
            productId = id;
            unitPrice = price;
            stockLimit = maxQty > 0 ? maxQty : 1;

            BNProductName.Text = name;
            Price.Text = $"₱{price:N2}";
            Picture.Image = image;
            Picture.SizeMode = PictureBoxSizeMode.Zoom;

            // Only what is still available after what is already in the cart may be added.
            int remaining = stockLimit - CartManager.GetQuantity(id);
            canAdd = remaining > 0;

            Quantity_UpDown.Minimum = 1;
            Quantity_UpDown.Maximum = maxQty > 0 ? maxQty : 1;
            Quantity_UpDown.Value = 1;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmBuy_Button_Click(object sender, EventArgs e)
        {

            if (!canAdd)
            {
                MessageBox.Show("You already have all the available stock of this item in your cart.",
                    "HiveStock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int qty = (int)Quantity_UpDown.Value;
            CartManager.AddItem(productId, BNProductName.Text, unitPrice, Picture.Image, qty, stockLimit);
            MessageBox.Show("Added to cart!", "HiveStock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void L_Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
