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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void LogOut_Button_Click_1(object sender, EventArgs e)
        {
            LogIn_Register loginregister = new LogIn_Register();
            loginregister.Show();
            this.Hide();
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            PM_CreateProduct createProductForm = new PM_CreateProduct();
            createProductForm.ShowDialog();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            PM_EditProduct editProductForm = new PM_EditProduct();
            editProductForm.ShowDialog();
        }
    }
}