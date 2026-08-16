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
    public partial class PM_CreateProduct : Form
    {
        public PM_CreateProduct()
        {
            InitializeComponent();
        }

        private void CPCancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CPCreate_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
