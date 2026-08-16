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
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }

        private void L_Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuyNow_Button_Click(object sender, EventArgs e)
        {
            Upload_QR uploadQR = new Upload_QR();
            uploadQR.ShowDialog();
        }
    }
}
