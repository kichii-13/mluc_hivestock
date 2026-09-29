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

        public AddToCart_PopUp()
        {
            InitializeComponent();
        }
        public void SetProduct(int id, string name, decimal price, Image image, int maxQty)
        {
            productId = id;
            unitPrice = price;

            BNProductName.Text = name;
            Price.Text = $"₱{price:N2}";
            Picture.Image = image;
            Picture.SizeMode = PictureBoxSizeMode.Zoom;

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
            int qty = (int)Quantity_UpDown.Value;
            CartManager.AddItem(productId, BNProductName.Text, unitPrice, Picture.Image, qty);
            MessageBox.Show("Added to cart!", "HiveStock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void L_Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
