using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace LogIn_HiveStock
{
    public partial class Upload_QR : Form
    {
        // File name of the receipt picture the user chose; empty until one is uploaded.
        private string receiptFileName = "";
        // full path of the picture the student chose
        private string receiptSourcePath = "";  
       
        public Upload_QR()
        {
            InitializeComponent();

            FileName_Label.Text = "No receipt uploaded yet";
            Receipt_Image.SizeMode = PictureBoxSizeMode.Zoom;
            Upload_Button.Click += Upload_Button_Click;
        }

        private void Upload_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select a picture of your payment receipt";
                dialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dialog.CheckFileExists = true;

                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    // Copy into a Bitmap so the file on disk is not left locked.
                    Image loaded;
                    using (FileStream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read))
                    using (Image temp = Image.FromStream(stream))
                    {
                        loaded = new Bitmap(temp);
                    }

                    Image previous = Receipt_Image.Image;
                    Receipt_Image.Image = loaded;
                    if (previous != null) previous.Dispose();

                    // The label under the preview now shows the name of the uploaded receipt.
                    receiptFileName = Path.GetFileName(dialog.FileName);
                    receiptSourcePath = dialog.FileName;
                    FileName_Label.Text = receiptFileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("That file could not be opened as a picture. Please choose an image of your receipt (JPG, PNG, BMP or GIF).",
                        "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Done_Click(object sender, EventArgs e)
        {
            // A receipt picture is required before the payment can be submitted.
            if (string.IsNullOrEmpty(receiptFileName) || Receipt_Image.Image == null)
            {
                MessageBox.Show("Please upload a picture of your payment receipt before submitting.",
                    "Receipt Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CartManager.Items.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "HiveStock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            // Keep a copy of the receipt picture so staff can view it later, then record the order.
            string savedReceipt;
            try
            {
                savedReceipt = ProductImages.SaveReceipt(receiptSourcePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The receipt picture could not be saved: " + ex.Message,
                    "Receipt Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OrderRecord placed = OrderManager.PlaceOrder(UserSession.OrderKey, CartManager.Items, savedReceipt);
            if (placed == null)
            {
                // The order failed (a message was already shown): keep the cart and drop the copy.
                try { File.Delete(Path.Combine(ProductImages.ReceiptsFolder(), savedReceipt)); } catch { }
                return;
            }
            CartManager.Clear();

            using (PaymentComplete paymentCompleteForm = new PaymentComplete())
            {
                paymentCompleteForm.ShowDialog(this);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (Receipt_Image.Image != null)
            {
                Receipt_Image.Image.Dispose();
                Receipt_Image.Image = null;
            }
        }
    }
}
