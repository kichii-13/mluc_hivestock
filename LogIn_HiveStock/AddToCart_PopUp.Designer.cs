namespace LogIn_HiveStock
{
    partial class AddToCart_PopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddToCart_PopUp));
            this.AddToCart_Label = new System.Windows.Forms.Label();
            this.Description_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.Quantity_UpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.Quantity_Label = new System.Windows.Forms.Label();
            this.Cancel_Button = new Guna.UI2.WinForms.Guna2Button();
            this.ConfirmBuy_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Price = new System.Windows.Forms.Label();
            this.Price_Label = new System.Windows.Forms.Label();
            this.BNProductName = new System.Windows.Forms.Label();
            this.Picture_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.Picture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ATCPU_Back_Button = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Description_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity_UpDown)).BeginInit();
            this.Picture_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // AddToCart_Label
            // 
            this.AddToCart_Label.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToCart_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.AddToCart_Label.Location = new System.Drawing.Point(0, 13);
            this.AddToCart_Label.Name = "AddToCart_Label";
            this.AddToCart_Label.Size = new System.Drawing.Size(485, 36);
            this.AddToCart_Label.TabIndex = 0;
            this.AddToCart_Label.Text = "ADD TO CART";
            this.AddToCart_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Description_Panel
            // 
            this.Description_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Description_Panel.BorderRadius = 10;
            this.Description_Panel.Controls.Add(this.Quantity_UpDown);
            this.Description_Panel.Controls.Add(this.Quantity_Label);
            this.Description_Panel.Controls.Add(this.Cancel_Button);
            this.Description_Panel.Controls.Add(this.ConfirmBuy_Button);
            this.Description_Panel.Controls.Add(this.Price);
            this.Description_Panel.Controls.Add(this.Price_Label);
            this.Description_Panel.Controls.Add(this.BNProductName);
            this.Description_Panel.Controls.Add(this.Picture_Panel);
            this.Description_Panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.Description_Panel.ForeColor = System.Drawing.Color.Transparent;
            this.Description_Panel.Location = new System.Drawing.Point(12, 59);
            this.Description_Panel.Name = "Description_Panel";
            this.Description_Panel.Size = new System.Drawing.Size(460, 187);
            this.Description_Panel.TabIndex = 1;
            // 
            // Quantity_UpDown
            // 
            this.Quantity_UpDown.BackColor = System.Drawing.Color.Transparent;
            this.Quantity_UpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.Quantity_UpDown.BorderRadius = 5;
            this.Quantity_UpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Quantity_UpDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Quantity_UpDown.Location = new System.Drawing.Point(400, 102);
            this.Quantity_UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Quantity_UpDown.Name = "Quantity_UpDown";
            this.Quantity_UpDown.Size = new System.Drawing.Size(51, 25);
            this.Quantity_UpDown.TabIndex = 8;
            this.Quantity_UpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.Quantity_UpDown.UpDownButtonForeColor = System.Drawing.Color.Black;
            this.Quantity_UpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Quantity_Label
            // 
            this.Quantity_Label.AutoSize = true;
            this.Quantity_Label.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity_Label.ForeColor = System.Drawing.Color.Black;
            this.Quantity_Label.Location = new System.Drawing.Point(342, 106);
            this.Quantity_Label.Name = "Quantity_Label";
            this.Quantity_Label.Size = new System.Drawing.Size(61, 17);
            this.Quantity_Label.TabIndex = 9;
            this.Quantity_Label.Text = "Quantity:";
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
            this.Cancel_Button.Location = new System.Drawing.Point(241, 130);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(83, 37);
            this.Cancel_Button.TabIndex = 7;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // ConfirmBuy_Button
            // 
            this.ConfirmBuy_Button.BorderRadius = 8;
            this.ConfirmBuy_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ConfirmBuy_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ConfirmBuy_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ConfirmBuy_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ConfirmBuy_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.ConfirmBuy_Button.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBuy_Button.ForeColor = System.Drawing.Color.White;
            this.ConfirmBuy_Button.Location = new System.Drawing.Point(329, 130);
            this.ConfirmBuy_Button.Name = "ConfirmBuy_Button";
            this.ConfirmBuy_Button.Size = new System.Drawing.Size(122, 37);
            this.ConfirmBuy_Button.TabIndex = 6;
            this.ConfirmBuy_Button.Text = "Add To Cart";
            this.ConfirmBuy_Button.Click += new System.EventHandler(this.ConfirmBuy_Button_Click);
            // 
            // Price
            // 
            this.Price.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.ForeColor = System.Drawing.Color.Black;
            this.Price.Location = new System.Drawing.Point(273, 106);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(74, 20);
            this.Price.TabIndex = 5;
            this.Price.Text = "₱250.00";
            // 
            // Price_Label
            // 
            this.Price_Label.AutoSize = true;
            this.Price_Label.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price_Label.ForeColor = System.Drawing.Color.Black;
            this.Price_Label.Location = new System.Drawing.Point(241, 106);
            this.Price_Label.Name = "Price_Label";
            this.Price_Label.Size = new System.Drawing.Size(44, 17);
            this.Price_Label.TabIndex = 4;
            this.Price_Label.Text = "Price: ";
            // 
            // BNProductName
            // 
            this.BNProductName.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNProductName.ForeColor = System.Drawing.Color.Black;
            this.BNProductName.Location = new System.Drawing.Point(240, 9);
            this.BNProductName.Name = "BNProductName";
            this.BNProductName.Size = new System.Drawing.Size(217, 65);
            this.BNProductName.TabIndex = 3;
            this.BNProductName.Text = "Art Appreciation";
            this.BNProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Picture_Panel
            // 
            this.Picture_Panel.BorderRadius = 10;
            this.Picture_Panel.Controls.Add(this.Picture);
            this.Picture_Panel.FillColor = System.Drawing.Color.White;
            this.Picture_Panel.Location = new System.Drawing.Point(11, 20);
            this.Picture_Panel.Name = "Picture_Panel";
            this.Picture_Panel.Size = new System.Drawing.Size(223, 149);
            this.Picture_Panel.TabIndex = 2;
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.Transparent;
            this.Picture.BorderRadius = 10;
            this.Picture.FillColor = System.Drawing.Color.Transparent;
            this.Picture.Image = global::LogIn_HiveStock.Properties.Resources.dmmmsu_logo;
            this.Picture.ImageRotate = 0F;
            this.Picture.Location = new System.Drawing.Point(16, 4);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(191, 141);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Picture.TabIndex = 1;
            this.Picture.TabStop = false;
            this.Picture.UseTransparentBackground = true;
            // 
            // ATCPU_Back_Button
            // 
            this.ATCPU_Back_Button.BackColor = System.Drawing.Color.Transparent;
            this.ATCPU_Back_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ATCPU_Back_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ATCPU_Back_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ATCPU_Back_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ATCPU_Back_Button.FillColor = System.Drawing.Color.White;
            this.ATCPU_Back_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ATCPU_Back_Button.ForeColor = System.Drawing.Color.White;
            this.ATCPU_Back_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.ATCPU_Back_Button.Image = ((System.Drawing.Image)(resources.GetObject("ATCPU_Back_Button.Image")));
            this.ATCPU_Back_Button.ImageOffset = new System.Drawing.Point(-1, 0);
            this.ATCPU_Back_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.ATCPU_Back_Button.IndicateFocus = true;
            this.ATCPU_Back_Button.Location = new System.Drawing.Point(12, 12);
            this.ATCPU_Back_Button.Name = "ATCPU_Back_Button";
            this.ATCPU_Back_Button.PressedColor = System.Drawing.Color.White;
            this.ATCPU_Back_Button.PressedDepth = 100;
            this.ATCPU_Back_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ATCPU_Back_Button.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ATCPU_Back_Button.Size = new System.Drawing.Size(40, 40);
            this.ATCPU_Back_Button.TabIndex = 13;
            this.ATCPU_Back_Button.Click += new System.EventHandler(this.L_Back_Button_Click);
            // 
            // AddToCart_PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.ATCPU_Back_Button);
            this.Controls.Add(this.Description_Panel);
            this.Controls.Add(this.AddToCart_Label);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddToCart_PopUp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buy Now";
            this.Description_Panel.ResumeLayout(false);
            this.Description_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity_UpDown)).EndInit();
            this.Picture_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label AddToCart_Label;
        private Guna.UI2.WinForms.Guna2Panel Description_Panel;
        private Guna.UI2.WinForms.Guna2Panel Picture_Panel;
        private Guna.UI2.WinForms.Guna2PictureBox Picture;
        private System.Windows.Forms.Label BNProductName;
        private System.Windows.Forms.Label Price_Label;
        private Guna.UI2.WinForms.Guna2Button ConfirmBuy_Button;
        private System.Windows.Forms.Label Price;
        private Guna.UI2.WinForms.Guna2Button Cancel_Button;
        private Guna.UI2.WinForms.Guna2CircleButton ATCPU_Back_Button;
        private Guna.UI2.WinForms.Guna2NumericUpDown Quantity_UpDown;
        private System.Windows.Forms.Label Quantity_Label;
    }
}