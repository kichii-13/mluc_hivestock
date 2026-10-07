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
    public partial class PaymentComplete : Form
    {
        public PaymentComplete()
        {
            InitializeComponent();

            label1.Text = "Receipt Submitted!";

            // the new paragraph is longer, so give it a bit more room (the Okay button is at y = 228)
            label1.Top = 70;
            label2.AutoSize = false;
            label2.Top = 128;
            label2.Height = 90;
            label2.Text = "Your payment receipt is now being verified. " +
                          "Once your order is marked as Paid, you may head to the Marketing Center to claim your item(s). " +
                          "You can follow its status under Pending Orders in your Profile.";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
