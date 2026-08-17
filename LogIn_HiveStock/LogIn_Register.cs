using System;
using System.Windows.Forms;

namespace LogIn_HiveStock
{
    public partial class LogIn_Register : Form
    {
        public LogIn_Register()
        {
            InitializeComponent();
        }

        private void LogIn_Register_Load(object sender, EventArgs e)
        {
            ShowPanel(LogIn_Panel);
        }

        private void ShowPanel(Panel panel)
        {
            LogIn_Panel.Visible = false;
            Register_Panel.Visible = false;

            panel.Visible = true;
            panel.BringToFront();
        }

        private void SignUp_Hyperlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPanel(Register_Panel);
        }

        private void LogIn_Hyperlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPanel(LogIn_Panel);
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            UserView_ProductCatalog catalog = new UserView_ProductCatalog();
            catalog.Show();
            this.Hide();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            ShowPanel(LogIn_Panel);
        }

        private void R_Back_Button_Click(object sender, EventArgs e)
        {
            ShowPanel(LogIn_Panel);
        }

        private void LogIn_Button_Click(object sender, EventArgs e)
        {
            UserView_ProductCatalog catalog = new UserView_ProductCatalog();
            catalog.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AdminSide adminside = new AdminSide();
            adminside.Show();
            this.Hide();
        }

        private void ForgotPassword_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgot_Panel.Visible = true;
            ForgotPassword_Label.Visible = true;
        }

        private void ForgotCancel_Button_Click(object sender, EventArgs e)
        {
            Forgot_Panel.Visible = false;
            ForgotPassword_Label.Visible = false;
        }

        private void Done_Button_Click(object sender, EventArgs e)
        {
            Forgot_Panel.Visible = false;
            ForgotPassword_Label.Visible = false;
        }
    }
}