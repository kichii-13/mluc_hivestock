namespace LogIn_HiveStock
{
    partial class Notification_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notification_Management));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Notification_Button = new Guna.UI2.WinForms.Guna2Button();
            this.ProductManagement_Button = new Guna.UI2.WinForms.Guna2Button();
            this.AdminDashboard_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Header_Panel = new System.Windows.Forms.Panel();
            this.MarketingCenter = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Header_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(538, 302);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 65);
            this.label2.TabIndex = 3;
            this.label2.Text = "Coming Soon...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.Exit_Button);
            this.panel1.Controls.Add(this.Notification_Button);
            this.panel1.Controls.Add(this.ProductManagement_Button);
            this.panel1.Controls.Add(this.AdminDashboard_Button);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 682);
            this.panel1.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.pictureBox2);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(183, 149);
            this.panel8.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "HiveStock";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(48, 21);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 91);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // Exit_Button
            // 
            this.Exit_Button.BorderRadius = 6;
            this.Exit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Exit_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Exit_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Exit_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Exit_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.Exit_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_Button.ForeColor = System.Drawing.Color.Black;
            this.Exit_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.Exit_Button.Location = new System.Drawing.Point(11, 631);
            this.Exit_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(159, 29);
            this.Exit_Button.TabIndex = 21;
            this.Exit_Button.Text = "EXIT";
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Notification_Button
            // 
            this.Notification_Button.BorderRadius = 6;
            this.Notification_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Notification_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Notification_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Notification_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Notification_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Notification_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.Notification_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notification_Button.ForeColor = System.Drawing.Color.Black;
            this.Notification_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.Notification_Button.Location = new System.Drawing.Point(11, 279);
            this.Notification_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Notification_Button.Name = "Notification_Button";
            this.Notification_Button.Size = new System.Drawing.Size(159, 34);
            this.Notification_Button.TabIndex = 20;
            this.Notification_Button.Text = "Notification Management";
            // 
            // ProductManagement_Button
            // 
            this.ProductManagement_Button.BorderRadius = 6;
            this.ProductManagement_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductManagement_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ProductManagement_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ProductManagement_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ProductManagement_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ProductManagement_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.ProductManagement_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductManagement_Button.ForeColor = System.Drawing.Color.Black;
            this.ProductManagement_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.ProductManagement_Button.Location = new System.Drawing.Point(11, 225);
            this.ProductManagement_Button.Margin = new System.Windows.Forms.Padding(2);
            this.ProductManagement_Button.Name = "ProductManagement_Button";
            this.ProductManagement_Button.Size = new System.Drawing.Size(159, 34);
            this.ProductManagement_Button.TabIndex = 19;
            this.ProductManagement_Button.Text = "Product Management";
            this.ProductManagement_Button.Click += new System.EventHandler(this.ProductManagement_Button_Click);
            // 
            // AdminDashboard_Button
            // 
            this.AdminDashboard_Button.BorderRadius = 6;
            this.AdminDashboard_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AdminDashboard_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AdminDashboard_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AdminDashboard_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AdminDashboard_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.AdminDashboard_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminDashboard_Button.ForeColor = System.Drawing.Color.Black;
            this.AdminDashboard_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.AdminDashboard_Button.Location = new System.Drawing.Point(11, 168);
            this.AdminDashboard_Button.Margin = new System.Windows.Forms.Padding(2);
            this.AdminDashboard_Button.Name = "AdminDashboard_Button";
            this.AdminDashboard_Button.Size = new System.Drawing.Size(159, 34);
            this.AdminDashboard_Button.TabIndex = 5;
            this.AdminDashboard_Button.Text = "Admin Dashboard";
            this.AdminDashboard_Button.Click += new System.EventHandler(this.AdminDashboard_Button_Click);
            // 
            // Header_Panel
            // 
            this.Header_Panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Header_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.Header_Panel.Controls.Add(this.MarketingCenter);
            this.Header_Panel.Location = new System.Drawing.Point(181, 0);
            this.Header_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Header_Panel.Name = "Header_Panel";
            this.Header_Panel.Size = new System.Drawing.Size(1086, 64);
            this.Header_Panel.TabIndex = 6;
            this.Header_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Header_Panel_Paint);
            // 
            // MarketingCenter
            // 
            this.MarketingCenter.AutoSize = true;
            this.MarketingCenter.BackColor = System.Drawing.Color.Transparent;
            this.MarketingCenter.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarketingCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.MarketingCenter.Location = new System.Drawing.Point(13, 15);
            this.MarketingCenter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MarketingCenter.Name = "MarketingCenter";
            this.MarketingCenter.Size = new System.Drawing.Size(367, 32);
            this.MarketingCenter.TabIndex = 6;
            this.MarketingCenter.Text = "NOTIFICATION MANAGEMENT";
            // 
            // Notification_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Header_Panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Notification_Management";
            this.Text = "Notification Management";
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Header_Panel.ResumeLayout(false);
            this.Header_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button Exit_Button;
        private Guna.UI2.WinForms.Guna2Button Notification_Button;
        private Guna.UI2.WinForms.Guna2Button ProductManagement_Button;
        private Guna.UI2.WinForms.Guna2Button AdminDashboard_Button;
        private System.Windows.Forms.Panel Header_Panel;
        private System.Windows.Forms.Label MarketingCenter;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}