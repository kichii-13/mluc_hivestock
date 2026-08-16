namespace LogIn_HiveStock
{
    partial class Upload_QR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Upload_QR));
            this.Description_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.AccountName_Label = new System.Windows.Forms.Label();
            this.QR_Image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ScanToPay_Label = new System.Windows.Forms.Label();
            this.UploadQR_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.FileName_Label = new System.Windows.Forms.Label();
            this.Upload_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Receipt_Image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Cancel_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Done = new Guna.UI2.WinForms.Guna2Button();
            this.Description_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QR_Image)).BeginInit();
            this.UploadQR_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Receipt_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Description_Panel
            // 
            this.Description_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Description_Panel.BorderRadius = 10;
            this.Description_Panel.Controls.Add(this.AccountName_Label);
            this.Description_Panel.Controls.Add(this.QR_Image);
            this.Description_Panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.Description_Panel.ForeColor = System.Drawing.Color.Transparent;
            this.Description_Panel.Location = new System.Drawing.Point(14, 46);
            this.Description_Panel.Name = "Description_Panel";
            this.Description_Panel.Size = new System.Drawing.Size(233, 242);
            this.Description_Panel.TabIndex = 2;
            // 
            // AccountName_Label
            // 
            this.AccountName_Label.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName_Label.ForeColor = System.Drawing.Color.Black;
            this.AccountName_Label.Location = new System.Drawing.Point(0, 198);
            this.AccountName_Label.Name = "AccountName_Label";
            this.AccountName_Label.Size = new System.Drawing.Size(233, 34);
            this.AccountName_Label.TabIndex = 6;
            this.AccountName_Label.Text = "Account Name: \r\nDMMMSU Marketing Center";
            this.AccountName_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // QR_Image
            // 
            this.QR_Image.Image = ((System.Drawing.Image)(resources.GetObject("QR_Image.Image")));
            this.QR_Image.ImageRotate = 0F;
            this.QR_Image.Location = new System.Drawing.Point(11, 11);
            this.QR_Image.Name = "QR_Image";
            this.QR_Image.Size = new System.Drawing.Size(213, 185);
            this.QR_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QR_Image.TabIndex = 5;
            this.QR_Image.TabStop = false;
            // 
            // ScanToPay_Label
            // 
            this.ScanToPay_Label.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanToPay_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.ScanToPay_Label.Location = new System.Drawing.Point(0, 4);
            this.ScanToPay_Label.Name = "ScanToPay_Label";
            this.ScanToPay_Label.Size = new System.Drawing.Size(499, 36);
            this.ScanToPay_Label.TabIndex = 5;
            this.ScanToPay_Label.Text = "SCAN TO PAY";
            this.ScanToPay_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UploadQR_Panel
            // 
            this.UploadQR_Panel.BackColor = System.Drawing.Color.Transparent;
            this.UploadQR_Panel.BorderRadius = 10;
            this.UploadQR_Panel.Controls.Add(this.Done);
            this.UploadQR_Panel.Controls.Add(this.FileName_Label);
            this.UploadQR_Panel.Controls.Add(this.Upload_Button);
            this.UploadQR_Panel.Controls.Add(this.Receipt_Image);
            this.UploadQR_Panel.Controls.Add(this.Cancel_Button);
            this.UploadQR_Panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.UploadQR_Panel.ForeColor = System.Drawing.Color.Transparent;
            this.UploadQR_Panel.Location = new System.Drawing.Point(252, 46);
            this.UploadQR_Panel.Name = "UploadQR_Panel";
            this.UploadQR_Panel.Size = new System.Drawing.Size(233, 242);
            this.UploadQR_Panel.TabIndex = 6;
            // 
            // FileName_Label
            // 
            this.FileName_Label.AutoEllipsis = true;
            this.FileName_Label.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileName_Label.ForeColor = System.Drawing.Color.Black;
            this.FileName_Label.Location = new System.Drawing.Point(10, 129);
            this.FileName_Label.Name = "FileName_Label";
            this.FileName_Label.Size = new System.Drawing.Size(212, 24);
            this.FileName_Label.TabIndex = 10;
            this.FileName_Label.Text = "filename.jpeg";
            this.FileName_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Upload_Button
            // 
            this.Upload_Button.BorderRadius = 8;
            this.Upload_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Upload_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Upload_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Upload_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Upload_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.Upload_Button.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Upload_Button.ForeColor = System.Drawing.Color.Black;
            this.Upload_Button.Location = new System.Drawing.Point(10, 156);
            this.Upload_Button.Name = "Upload_Button";
            this.Upload_Button.Size = new System.Drawing.Size(212, 45);
            this.Upload_Button.TabIndex = 9;
            this.Upload_Button.Text = "Upload Receipt";
            // 
            // Receipt_Image
            // 
            this.Receipt_Image.BorderRadius = 5;
            this.Receipt_Image.ImageRotate = 0F;
            this.Receipt_Image.Location = new System.Drawing.Point(10, 11);
            this.Receipt_Image.Name = "Receipt_Image";
            this.Receipt_Image.Size = new System.Drawing.Size(212, 115);
            this.Receipt_Image.TabIndex = 8;
            this.Receipt_Image.TabStop = false;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.BorderRadius = 8;
            this.Cancel_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Cancel_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Cancel_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Cancel_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Cancel_Button.FillColor = System.Drawing.Color.Gray;
            this.Cancel_Button.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_Button.ForeColor = System.Drawing.Color.Black;
            this.Cancel_Button.Location = new System.Drawing.Point(10, 205);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(72, 30);
            this.Cancel_Button.TabIndex = 7;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Done
            // 
            this.Done.BorderRadius = 8;
            this.Done.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Done.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Done.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Done.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Done.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.Done.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done.ForeColor = System.Drawing.Color.Black;
            this.Done.Location = new System.Drawing.Point(88, 205);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(134, 30);
            this.Done.TabIndex = 11;
            this.Done.Text = "Done";
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // Upload_QR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.UploadQR_Panel);
            this.Controls.Add(this.ScanToPay_Label);
            this.Controls.Add(this.Description_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Upload_QR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload QR";
            this.Description_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QR_Image)).EndInit();
            this.UploadQR_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Receipt_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel Description_Panel;
        private System.Windows.Forms.Label ScanToPay_Label;
        private Guna.UI2.WinForms.Guna2PictureBox QR_Image;
        private System.Windows.Forms.Label AccountName_Label;
        private Guna.UI2.WinForms.Guna2Panel UploadQR_Panel;
        private Guna.UI2.WinForms.Guna2Button Cancel_Button;
        private Guna.UI2.WinForms.Guna2PictureBox Receipt_Image;
        private System.Windows.Forms.Label FileName_Label;
        private Guna.UI2.WinForms.Guna2Button Upload_Button;
        private Guna.UI2.WinForms.Guna2Button Done;
    }
}