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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Profile_Back_Button_Click(object sender, EventArgs e)
        {
            UserView_ProductCatalog userView = new UserView_ProductCatalog();
            userView.Show();
            this.Close();
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void EditDetails_Button_Click(object sender, EventArgs e)
        {
            EditDetails_Panel.Visible = true;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            EditDetails_Panel.Visible = false;
        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            LogIn_Register logIn = new LogIn_Register();
            logIn.Show();
            this.Close();
        }

        private void EditDone_Button_Click(object sender, EventArgs e)
        {
            EditDetails_Panel.Visible = false;
        }
    }
}
