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
    public partial class PM_EditProduct : Form
    {
        public PM_EditProduct()
        {
            InitializeComponent();
        }

        private void EPCancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EPCreate_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
