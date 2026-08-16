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
    public partial class Notify_PopUp : Form
    {
        public Notify_PopUp()
        {
            InitializeComponent();
        }

        private void ATCPU_Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmBuy_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReceiveAlert_Check_CheckedChanged(object sender, EventArgs e)
        {
            NotifyMe_Button.Enabled = ReceiveAlert_Check.Checked;
        }
    }
}
