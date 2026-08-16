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
    public partial class UserView_ProductCatalog : Form
    {
        public UserView_ProductCatalog()
        {
            InitializeComponent();
        }

        private void ATC1_Button_Click(object sender, EventArgs e)
        {
            AddToCart_PopUp AddToCart = new AddToCart_PopUp();
            AddToCart.ShowDialog();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Cart_Button_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.ShowDialog();
        }

        private void Notify3_Button_Click(object sender, EventArgs e)
        {
            Notify_PopUp notify = new Notify_PopUp();
            notify.ShowDialog();
        }

        private void Profile_Button_Click_1(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();

            this.Hide();
        }
    }
}
