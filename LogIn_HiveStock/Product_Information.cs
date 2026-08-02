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
    public partial class Product_Information : Form
    {
        public Product_Information()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var f = new Create_Product();   // replace with your target form class
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Edit_Product();   // replace with your target form class
            f.Show();
        }

        private void AdminDashboard_Button_Click(object sender, EventArgs e)
        {
            var f = new Admin_Dashboard();
            f.Show();
            this.Hide();
        }

        private void NotificationButton_Click_1(object sender, EventArgs e)
        {
            var f = new Notification_Management();
            f.Show();
            this.Hide();
        }

        private void ProductManagementButton_Click_1(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var f = new UserView_ProductCatalog();
            f.Show();
            this.Hide();
        }
    }
}
