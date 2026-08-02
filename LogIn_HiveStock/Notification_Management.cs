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
    public partial class Notification_Management : Form
    {
        public Notification_Management()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new Admin_Dashboard();   // replace with your target form class
            f.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new Product_Information();   // replace with your target form class
            f.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var f = new Notification_Management();   // replace with your target form class
            f.Show();
            this.Close();
        }

        private void Header_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminDashboard_Button_Click(object sender, EventArgs e)
        {
            var f = new Admin_Dashboard();
            f.Show();
            this.Hide();
        }

        private void ProductManagement_Button_Click(object sender, EventArgs e)
        {
            var f = new Product_Information();
            f.Show();
            this.Hide();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            var f = new UserView_ProductCatalog();
            f.Show();
            this.Hide();
        }
    }
}
