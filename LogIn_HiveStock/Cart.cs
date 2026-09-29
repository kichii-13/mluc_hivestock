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
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
            this.Load += Cart_Load;

            Product1Delete_Button.Click += (s, e) => RemoveAndRefresh(0);
            Product2Delete_Button.Click += (s, e) => RemoveAndRefresh(1);
            Product3Delete_Button.Click += (s, e) => RemoveAndRefresh(2);
        }
        private void Cart_Load(object sender, EventArgs e)
        {
            LoadCartData();
        }

        private void LoadCartData()
        {
            var panels = new[] { Product1_Panel, Product2_Panel, Product3_Panel };
            var images = new[] { Product1_Image, Product2_Image, Product3_Image };
            var labels = new[] { Product1_Label, Product2_Label, Product3_Label };
            var prices = new[] { Product1Price_Label, Product2Price_Label, Product3Price_Label };
            var upDowns = new[] { Product1_UpDown, Product2_UpDown, Product3_UpDown };

            for (int i = 0; i < panels.Length; i++)
            {
                if (i < CartManager.Items.Count)
                {
                    CartItem item = CartManager.Items[i];
                    panels[i].Visible = true;
                    images[i].Image = item.Image;
                    images[i].SizeMode = PictureBoxSizeMode.Zoom;
                    labels[i].Text = item.Name;
                    prices[i].Text = $"₱{item.Price:N2}";
                    upDowns[i].Minimum = 1;
                    upDowns[i].Value = item.Quantity;
                }
                else
                {
                    panels[i].Visible = false;
                }
            }

            UpdateTotal();
        }
        private void RemoveAndRefresh(int index)
        {
            if (index < CartManager.Items.Count)
                CartManager.Items.RemoveAt(index);

            LoadCartData();
        }
        private void UpdateTotal()
        {
            decimal total = CartManager.Items.Sum(i => i.Price * i.Quantity);
            PesoTotal_Label.Text = $"₱{total:N2}";
            ProductTotal_Label.Text = CartManager.Items.Count.ToString();
        }

        private void L_Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuyNow_Button_Click(object sender, EventArgs e)
        {
            Upload_QR uploadQR = new Upload_QR();
            uploadQR.ShowDialog();
        }
    }
}
