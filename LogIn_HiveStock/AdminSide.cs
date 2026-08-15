using System;
using System.Windows.Forms;

namespace LogIn_HiveStock
{
    public partial class AdminSide : Form
    {
        public AdminSide()
        {
            InitializeComponent();
        }

        private void AdminSide_Load(object sender, EventArgs e)
        {
            ShowPanel(AdminDashboard_Panel);
        }

        private void ShowPanel(Panel panel)
        {
            AdminDashboard_Panel.Visible = false;
            Product_Mgmt_Panel.Visible = false;
            OrderManagement_Panel.Visible = false;

            panel.Visible = true;
        }

        private void AdminDashboard_Button_Click(object sender, EventArgs e)
        {
            ShowPanel(AdminDashboard_Panel);
        }

        private void ProductManagement_Button_Click_1(object sender, EventArgs e)
        {
            ShowPanel(Product_Mgmt_Panel);
        }

        private void Notification_Button_Click(object sender, EventArgs e)
        {
            ShowPanel(OrderManagement_Panel);
        }

        private void Exit_Button_Click_1(object sender, EventArgs e)
        {
            UserView_ProductCatalog catalog = new UserView_ProductCatalog();
            catalog.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}