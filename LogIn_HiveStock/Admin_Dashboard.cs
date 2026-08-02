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

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new Admin_Dashboard();   // replace with your target form class
            f.Show();
            this.Close();
        }
    }
}
