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
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Button_Click(object sender, EventArgs e)
        {

        }

        private void ProductManagement_Button_Click(object sender, EventArgs e)
        {
            var f = new Product_Information();
            f.Show();
            this.Hide();
        }

        private void Notification_Button_Click(object sender, EventArgs e)
        {
            var f = new Notification_Management();
            f.Show();
            this.Hide();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            var f = new UserView_ProductCatalog();
            f.Show();
            this.Hide();
        }

        private void TotalProducts_DB_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
