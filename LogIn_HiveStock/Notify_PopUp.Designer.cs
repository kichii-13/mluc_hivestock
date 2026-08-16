namespace LogIn_HiveStock
{
    partial class Notify_PopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notify_PopUp));
            this.NPU_Back_Button = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Description_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.Picture_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.Picture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Product_Label = new System.Windows.Forms.Label();
            this.ReceiveAlert_Check = new Guna.UI2.WinForms.Guna2CheckBox();
            this.NotifyMe_Button = new Guna.UI2.WinForms.Guna2Button();
            this.GetNotified_Label = new System.Windows.Forms.Label();
            this.Description_Panel.SuspendLayout();
            this.Picture_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // NPU_Back_Button
            // 
            this.NPU_Back_Button.BackColor = System.Drawing.Color.Transparent;
            this.NPU_Back_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.NPU_Back_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.NPU_Back_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.NPU_Back_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.NPU_Back_Button.FillColor = System.Drawing.Color.White;
            this.NPU_Back_Button.FocusedColor = System.Drawing.Color.White;
            this.NPU_Back_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NPU_Back_Button.ForeColor = System.Drawing.Color.White;
            this.NPU_Back_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.NPU_Back_Button.Image = ((System.Drawing.Image)(resources.GetObject("NPU_Back_Button.Image")));
            this.NPU_Back_Button.ImageOffset = new System.Drawing.Point(-1, 0);
            this.NPU_Back_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.NPU_Back_Button.IndicateFocus = true;
            this.NPU_Back_Button.Location = new System.Drawing.Point(12, 12);
            this.NPU_Back_Button.Name = "NPU_Back_Button";
            this.NPU_Back_Button.PressedColor = System.Drawing.Color.White;
            this.NPU_Back_Button.PressedDepth = 100;
            this.NPU_Back_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NPU_Back_Button.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.NPU_Back_Button.Size = new System.Drawing.Size(40, 40);
            this.NPU_Back_Button.TabIndex = 14;
            this.NPU_Back_Button.Click += new System.EventHandler(this.ATCPU_Back_Button_Click);
            // 
            // Description_Panel
            // 
            this.Description_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Description_Panel.BorderRadius = 10;
            this.Description_Panel.Controls.Add(this.Picture_Panel);
            this.Description_Panel.Controls.Add(this.Product_Label);
            this.Description_Panel.Controls.Add(this.ReceiveAlert_Check);
            this.Description_Panel.Controls.Add(this.NotifyMe_Button);
            this.Description_Panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.Description_Panel.ForeColor = System.Drawing.Color.Transparent;
            this.Description_Panel.Location = new System.Drawing.Point(12, 59);
            this.Description_Panel.Name = "Description_Panel";
            this.Description_Panel.Size = new System.Drawing.Size(460, 187);
            this.Description_Panel.TabIndex = 15;
            // 
            // Picture_Panel
            // 
            this.Picture_Panel.BorderRadius = 10;
            this.Picture_Panel.Controls.Add(this.Picture);
            this.Picture_Panel.FillColor = System.Drawing.Color.White;
            this.Picture_Panel.Location = new System.Drawing.Point(11, 10);
            this.Picture_Panel.Name = "Picture_Panel";
            this.Picture_Panel.Size = new System.Drawing.Size(170, 123);
            this.Picture_Panel.TabIndex = 19;
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.Transparent;
            this.Picture.BorderRadius = 10;
            this.Picture.FillColor = System.Drawing.Color.Transparent;
            this.Picture.Image = global::LogIn_HiveStock.Properties.Resources.dmmmsu_logo;
            this.Picture.ImageRotate = 0F;
            this.Picture.Location = new System.Drawing.Point(0, 0);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(170, 123);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Picture.TabIndex = 1;
            this.Picture.TabStop = false;
            this.Picture.UseTransparentBackground = true;
            // 
            // Product_Label
            // 
            this.Product_Label.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product_Label.ForeColor = System.Drawing.Color.Black;
            this.Product_Label.Location = new System.Drawing.Point(187, 18);
            this.Product_Label.Name = "Product_Label";
            this.Product_Label.Size = new System.Drawing.Size(265, 107);
            this.Product_Label.TabIndex = 18;
            this.Product_Label.Text = "The Contemporary World";
            this.Product_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReceiveAlert_Check
            // 
            this.ReceiveAlert_Check.AutoSize = true;
            this.ReceiveAlert_Check.BackColor = System.Drawing.Color.Transparent;
            this.ReceiveAlert_Check.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.ReceiveAlert_Check.CheckedState.BorderRadius = 3;
            this.ReceiveAlert_Check.CheckedState.BorderThickness = 0;
            this.ReceiveAlert_Check.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.ReceiveAlert_Check.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiveAlert_Check.ForeColor = System.Drawing.Color.Black;
            this.ReceiveAlert_Check.Location = new System.Drawing.Point(10, 139);
            this.ReceiveAlert_Check.Name = "ReceiveAlert_Check";
            this.ReceiveAlert_Check.Size = new System.Drawing.Size(282, 19);
            this.ReceiveAlert_Check.TabIndex = 17;
            this.ReceiveAlert_Check.Text = "Receive an alert when this product is restocked.";
            this.ReceiveAlert_Check.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.ReceiveAlert_Check.UncheckedState.BorderRadius = 3;
            this.ReceiveAlert_Check.UncheckedState.BorderThickness = 1;
            this.ReceiveAlert_Check.UncheckedState.FillColor = System.Drawing.Color.White;
            this.ReceiveAlert_Check.UseVisualStyleBackColor = false;
            this.ReceiveAlert_Check.CheckedChanged += new System.EventHandler(this.ReceiveAlert_Check_CheckedChanged);
            // 
            // NotifyMe_Button
            // 
            this.NotifyMe_Button.BorderRadius = 8;
            this.NotifyMe_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.NotifyMe_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.NotifyMe_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.NotifyMe_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.NotifyMe_Button.Enabled = false;
            this.NotifyMe_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.NotifyMe_Button.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotifyMe_Button.ForeColor = System.Drawing.Color.Black;
            this.NotifyMe_Button.Location = new System.Drawing.Point(292, 130);
            this.NotifyMe_Button.Name = "NotifyMe_Button";
            this.NotifyMe_Button.Size = new System.Drawing.Size(159, 37);
            this.NotifyMe_Button.TabIndex = 6;
            this.NotifyMe_Button.Text = "Notify Me";
            this.NotifyMe_Button.Click += new System.EventHandler(this.ConfirmBuy_Button_Click);
            // 
            // GetNotified_Label
            // 
            this.GetNotified_Label.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetNotified_Label.ForeColor = System.Drawing.Color.White;
            this.GetNotified_Label.Location = new System.Drawing.Point(55, 18);
            this.GetNotified_Label.Name = "GetNotified_Label";
            this.GetNotified_Label.Size = new System.Drawing.Size(417, 28);
            this.GetNotified_Label.TabIndex = 3;
            this.GetNotified_Label.Text = "GET NOTIFIED WHEN STOCK IS AVAILABLE";
            this.GetNotified_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Notify_PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.Description_Panel);
            this.Controls.Add(this.GetNotified_Label);
            this.Controls.Add(this.NPU_Back_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notify_PopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notify_PopUp";
            this.Description_Panel.ResumeLayout(false);
            this.Description_Panel.PerformLayout();
            this.Picture_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleButton NPU_Back_Button;
        private Guna.UI2.WinForms.Guna2Panel Description_Panel;
        private Guna.UI2.WinForms.Guna2Button NotifyMe_Button;
        private System.Windows.Forms.Label GetNotified_Label;
        private Guna.UI2.WinForms.Guna2CheckBox ReceiveAlert_Check;
        private System.Windows.Forms.Label Product_Label;
        private Guna.UI2.WinForms.Guna2Panel Picture_Panel;
        private Guna.UI2.WinForms.Guna2PictureBox Picture;
    }
}