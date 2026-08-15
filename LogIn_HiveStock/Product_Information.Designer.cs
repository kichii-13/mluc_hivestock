namespace LogIn_HiveStock
{
    partial class Product_Information
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Product_Information));
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TP_Label = new System.Windows.Forms.Label();
            this.TotalProducts_DB = new System.Windows.Forms.Panel();
            this.TP_Color = new System.Windows.Forms.Panel();
            this.TP_Counter = new System.Windows.Forms.Label();
            this.InStock_DB = new System.Windows.Forms.Panel();
            this.IS_Counter = new System.Windows.Forms.Label();
            this.IS_Label = new System.Windows.Forms.Label();
            this.IS_Color = new System.Windows.Forms.Panel();
            this.Search_Label = new System.Windows.Forms.Label();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.ExitButton = new Guna.UI2.WinForms.Guna2Button();
            this.Notification_Button = new Guna.UI2.WinForms.Guna2Button();
            this.ProductManagement_Button = new Guna.UI2.WinForms.Guna2Button();
            this.AdminDashboard_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Logo_Panel = new System.Windows.Forms.Panel();
            this.HiveStock = new System.Windows.Forms.Label();
            this.DMMMSU_Logo = new System.Windows.Forms.PictureBox();
            this.Search_Input = new Guna.UI2.WinForms.Guna2TextBox();
            this.Header_Panel = new System.Windows.Forms.Panel();
            this.MarketingCenter = new System.Windows.Forms.Label();
            this.LS_Color = new System.Windows.Forms.Panel();
            this.LowStock_DB = new System.Windows.Forms.Panel();
            this.LS_Count = new System.Windows.Forms.Label();
            this.LS_Label = new System.Windows.Forms.Label();
            this.Product_Mgmt_Panel = new System.Windows.Forms.Panel();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Create_Button = new System.Windows.Forms.Button();
            this.OutOfStock_DB = new System.Windows.Forms.Panel();
            this.OOS_Count = new System.Windows.Forms.Label();
            this.OOS_Label = new System.Windows.Forms.Label();
            this.OOS_Color = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.TotalProducts_DB.SuspendLayout();
            this.InStock_DB.SuspendLayout();
            this.SidePanel.SuspendLayout();
            this.Logo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DMMMSU_Logo)).BeginInit();
            this.Header_Panel.SuspendLayout();
            this.LowStock_DB.SuspendLayout();
            this.Product_Mgmt_Panel.SuspendLayout();
            this.OutOfStock_DB.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataTable
            // 
            this.DataTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.DataTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataTable.ColumnHeadersHeight = 40;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.Category,
            this.Description,
            this.Price,
            this.StockQuantity,
            this.StockStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataTable.EnableHeadersVisualStyles = false;
            this.DataTable.GridColor = System.Drawing.Color.DarkOliveGreen;
            this.DataTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DataTable.Location = new System.Drawing.Point(258, 204);
            this.DataTable.Margin = new System.Windows.Forms.Padding(2);
            this.DataTable.Name = "DataTable";
            this.DataTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataTable.RowHeadersWidth = 51;
            this.DataTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DataTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DataTable.RowTemplate.Height = 24;
            this.DataTable.Size = new System.Drawing.Size(928, 446);
            this.DataTable.TabIndex = 0;
            this.DataTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "Product ID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Width = 95;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 155;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 125;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 170;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 90;
            // 
            // StockQuantity
            // 
            this.StockQuantity.HeaderText = "Stock Quantity";
            this.StockQuantity.MinimumWidth = 6;
            this.StockQuantity.Name = "StockQuantity";
            this.StockQuantity.ReadOnly = true;
            this.StockQuantity.Width = 120;
            // 
            // StockStatus
            // 
            this.StockStatus.HeaderText = "Stock Status";
            this.StockStatus.MinimumWidth = 6;
            this.StockStatus.Name = "StockStatus";
            this.StockStatus.ReadOnly = true;
            this.StockStatus.Width = 120;
            // 
            // TP_Label
            // 
            this.TP_Label.AutoSize = true;
            this.TP_Label.CausesValidation = false;
            this.TP_Label.Font = new System.Drawing.Font("Malgun Gothic", 7.8F);
            this.TP_Label.Location = new System.Drawing.Point(16, 10);
            this.TP_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TP_Label.Name = "TP_Label";
            this.TP_Label.Size = new System.Drawing.Size(81, 13);
            this.TP_Label.TabIndex = 2;
            this.TP_Label.Text = "Total Products";
            this.TP_Label.Click += new System.EventHandler(this.label8_Click);
            // 
            // TotalProducts_DB
            // 
            this.TotalProducts_DB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TotalProducts_DB.Controls.Add(this.TP_Color);
            this.TotalProducts_DB.Controls.Add(this.TP_Counter);
            this.TotalProducts_DB.Controls.Add(this.TP_Label);
            this.TotalProducts_DB.Location = new System.Drawing.Point(258, 78);
            this.TotalProducts_DB.Margin = new System.Windows.Forms.Padding(2);
            this.TotalProducts_DB.Name = "TotalProducts_DB";
            this.TotalProducts_DB.Size = new System.Drawing.Size(200, 63);
            this.TotalProducts_DB.TabIndex = 3;
            // 
            // TP_Color
            // 
            this.TP_Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.TP_Color.Location = new System.Drawing.Point(0, -1);
            this.TP_Color.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Color.Name = "TP_Color";
            this.TP_Color.Size = new System.Drawing.Size(8, 63);
            this.TP_Color.TabIndex = 4;
            // 
            // TP_Counter
            // 
            this.TP_Counter.AutoSize = true;
            this.TP_Counter.CausesValidation = false;
            this.TP_Counter.Font = new System.Drawing.Font("Malgun Gothic", 16.2F);
            this.TP_Counter.Location = new System.Drawing.Point(14, 27);
            this.TP_Counter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TP_Counter.Name = "TP_Counter";
            this.TP_Counter.Size = new System.Drawing.Size(25, 30);
            this.TP_Counter.TabIndex = 3;
            this.TP_Counter.Text = "0";
            // 
            // InStock_DB
            // 
            this.InStock_DB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.InStock_DB.Controls.Add(this.IS_Counter);
            this.InStock_DB.Controls.Add(this.IS_Label);
            this.InStock_DB.Controls.Add(this.IS_Color);
            this.InStock_DB.Location = new System.Drawing.Point(501, 78);
            this.InStock_DB.Margin = new System.Windows.Forms.Padding(2);
            this.InStock_DB.Name = "InStock_DB";
            this.InStock_DB.Size = new System.Drawing.Size(200, 63);
            this.InStock_DB.TabIndex = 4;
            // 
            // IS_Counter
            // 
            this.IS_Counter.AutoSize = true;
            this.IS_Counter.Font = new System.Drawing.Font("Malgun Gothic", 16.2F);
            this.IS_Counter.Location = new System.Drawing.Point(14, 27);
            this.IS_Counter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IS_Counter.Name = "IS_Counter";
            this.IS_Counter.Size = new System.Drawing.Size(25, 30);
            this.IS_Counter.TabIndex = 4;
            this.IS_Counter.Text = "0";
            // 
            // IS_Label
            // 
            this.IS_Label.AutoSize = true;
            this.IS_Label.Font = new System.Drawing.Font("Malgun Gothic", 7.8F);
            this.IS_Label.Location = new System.Drawing.Point(16, 10);
            this.IS_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IS_Label.Name = "IS_Label";
            this.IS_Label.Size = new System.Drawing.Size(48, 13);
            this.IS_Label.TabIndex = 2;
            this.IS_Label.Text = "In Stock";
            this.IS_Label.Click += new System.EventHandler(this.label9_Click);
            // 
            // IS_Color
            // 
            this.IS_Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.IS_Color.Location = new System.Drawing.Point(0, -1);
            this.IS_Color.Margin = new System.Windows.Forms.Padding(2);
            this.IS_Color.Name = "IS_Color";
            this.IS_Color.Size = new System.Drawing.Size(8, 63);
            this.IS_Color.TabIndex = 5;
            // 
            // Search_Label
            // 
            this.Search_Label.AutoSize = true;
            this.Search_Label.Location = new System.Drawing.Point(963, 170);
            this.Search_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Search_Label.Name = "Search_Label";
            this.Search_Label.Size = new System.Drawing.Size(41, 13);
            this.Search_Label.TabIndex = 11;
            this.Search_Label.Text = "Search";
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.SidePanel.Controls.Add(this.ExitButton);
            this.SidePanel.Controls.Add(this.Notification_Button);
            this.SidePanel.Controls.Add(this.ProductManagement_Button);
            this.SidePanel.Controls.Add(this.AdminDashboard_Button);
            this.SidePanel.Controls.Add(this.Logo_Panel);
            this.SidePanel.Location = new System.Drawing.Point(0, 0);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(2);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(183, 688);
            this.SidePanel.TabIndex = 12;
            // 
            // ExitButton
            // 
            this.ExitButton.BorderRadius = 6;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ExitButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ExitButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ExitButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ExitButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.ExitButton.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.Black;
            this.ExitButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.ExitButton.Location = new System.Drawing.Point(31, 631);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(120, 29);
            this.ExitButton.TabIndex = 21;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Notification_Button
            // 
            this.Notification_Button.BorderRadius = 6;
            this.Notification_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Notification_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Notification_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Notification_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Notification_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Notification_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.Notification_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notification_Button.ForeColor = System.Drawing.Color.Black;
            this.Notification_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.Notification_Button.Location = new System.Drawing.Point(31, 302);
            this.Notification_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Notification_Button.Name = "Notification_Button";
            this.Notification_Button.Size = new System.Drawing.Size(120, 43);
            this.Notification_Button.TabIndex = 20;
            this.Notification_Button.Text = "Notification Management";
            this.Notification_Button.Click += new System.EventHandler(this.NotificationButton_Click_1);
            // 
            // ProductManagement_Button
            // 
            this.ProductManagement_Button.BorderRadius = 6;
            this.ProductManagement_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductManagement_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ProductManagement_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ProductManagement_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ProductManagement_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ProductManagement_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.ProductManagement_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductManagement_Button.ForeColor = System.Drawing.Color.Black;
            this.ProductManagement_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.ProductManagement_Button.Location = new System.Drawing.Point(31, 240);
            this.ProductManagement_Button.Margin = new System.Windows.Forms.Padding(2);
            this.ProductManagement_Button.Name = "ProductManagement_Button";
            this.ProductManagement_Button.Size = new System.Drawing.Size(120, 43);
            this.ProductManagement_Button.TabIndex = 19;
            this.ProductManagement_Button.Text = "Product Management";
            this.ProductManagement_Button.Click += new System.EventHandler(this.ProductManagementButton_Click_1);
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
            this.AdminDashboard_Button.Location = new System.Drawing.Point(31, 179);
            this.AdminDashboard_Button.Margin = new System.Windows.Forms.Padding(2);
            this.AdminDashboard_Button.Name = "AdminDashboard_Button";
            this.AdminDashboard_Button.Size = new System.Drawing.Size(120, 43);
            this.AdminDashboard_Button.TabIndex = 5;
            this.AdminDashboard_Button.Text = "Admin Dashboard";
            this.AdminDashboard_Button.Click += new System.EventHandler(this.AdminDashboard_Button_Click);
            // 
            // Logo_Panel
            // 
            this.Logo_Panel.BackColor = System.Drawing.Color.White;
            this.Logo_Panel.Controls.Add(this.HiveStock);
            this.Logo_Panel.Controls.Add(this.DMMMSU_Logo);
            this.Logo_Panel.Location = new System.Drawing.Point(0, 0);
            this.Logo_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Logo_Panel.Name = "Logo_Panel";
            this.Logo_Panel.Size = new System.Drawing.Size(183, 149);
            this.Logo_Panel.TabIndex = 11;
            // 
            // HiveStock
            // 
            this.HiveStock.AutoSize = true;
            this.HiveStock.Font = new System.Drawing.Font("Malgun Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HiveStock.Location = new System.Drawing.Point(54, 114);
            this.HiveStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HiveStock.Name = "HiveStock";
            this.HiveStock.Size = new System.Drawing.Size(77, 19);
            this.HiveStock.TabIndex = 11;
            this.HiveStock.Text = "HiveStock";
            // 
            // DMMMSU_Logo
            // 
            this.DMMMSU_Logo.BackColor = System.Drawing.Color.Transparent;
            this.DMMMSU_Logo.Image = ((System.Drawing.Image)(resources.GetObject("DMMMSU_Logo.Image")));
            this.DMMMSU_Logo.Location = new System.Drawing.Point(48, 21);
            this.DMMMSU_Logo.Margin = new System.Windows.Forms.Padding(2);
            this.DMMMSU_Logo.Name = "DMMMSU_Logo";
            this.DMMMSU_Logo.Size = new System.Drawing.Size(87, 91);
            this.DMMMSU_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DMMMSU_Logo.TabIndex = 9;
            this.DMMMSU_Logo.TabStop = false;
            // 
            // Search_Input
            // 
            this.Search_Input.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.Search_Input.BorderRadius = 5;
            this.Search_Input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Search_Input.DefaultText = "";
            this.Search_Input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Search_Input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Search_Input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search_Input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search_Input.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.Search_Input.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_Input.ForeColor = System.Drawing.Color.Black;
            this.Search_Input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.Search_Input.Location = new System.Drawing.Point(1010, 164);
            this.Search_Input.Margin = new System.Windows.Forms.Padding(2);
            this.Search_Input.Name = "Search_Input";
            this.Search_Input.PlaceholderText = "Products";
            this.Search_Input.SelectedText = "";
            this.Search_Input.Size = new System.Drawing.Size(176, 27);
            this.Search_Input.TabIndex = 22;
            // 
            // Header_Panel
            // 
            this.Header_Panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Header_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.Header_Panel.Controls.Add(this.MarketingCenter);
            this.Header_Panel.Location = new System.Drawing.Point(182, 0);
            this.Header_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Header_Panel.Name = "Header_Panel";
            this.Header_Panel.Size = new System.Drawing.Size(1080, 64);
            this.Header_Panel.TabIndex = 23;
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
            this.MarketingCenter.Size = new System.Drawing.Size(312, 32);
            this.MarketingCenter.TabIndex = 6;
            this.MarketingCenter.Text = "PRODUCT MANAGEMENT";
            // 
            // LS_Color
            // 
            this.LS_Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.LS_Color.Location = new System.Drawing.Point(0, 0);
            this.LS_Color.Margin = new System.Windows.Forms.Padding(2);
            this.LS_Color.Name = "LS_Color";
            this.LS_Color.Size = new System.Drawing.Size(8, 63);
            this.LS_Color.TabIndex = 5;
            // 
            // LowStock_DB
            // 
            this.LowStock_DB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LowStock_DB.Controls.Add(this.LS_Count);
            this.LowStock_DB.Controls.Add(this.LS_Label);
            this.LowStock_DB.Controls.Add(this.LS_Color);
            this.LowStock_DB.Location = new System.Drawing.Point(742, 78);
            this.LowStock_DB.Margin = new System.Windows.Forms.Padding(2);
            this.LowStock_DB.Name = "LowStock_DB";
            this.LowStock_DB.Size = new System.Drawing.Size(200, 63);
            this.LowStock_DB.TabIndex = 6;
            // 
            // LS_Count
            // 
            this.LS_Count.AutoSize = true;
            this.LS_Count.Font = new System.Drawing.Font("Malgun Gothic", 16.2F);
            this.LS_Count.Location = new System.Drawing.Point(14, 27);
            this.LS_Count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LS_Count.Name = "LS_Count";
            this.LS_Count.Size = new System.Drawing.Size(25, 30);
            this.LS_Count.TabIndex = 4;
            this.LS_Count.Text = "0";
            // 
            // LS_Label
            // 
            this.LS_Label.AutoSize = true;
            this.LS_Label.Font = new System.Drawing.Font("Malgun Gothic", 7.8F);
            this.LS_Label.Location = new System.Drawing.Point(16, 10);
            this.LS_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LS_Label.Name = "LS_Label";
            this.LS_Label.Size = new System.Drawing.Size(59, 13);
            this.LS_Label.TabIndex = 2;
            this.LS_Label.Text = "Low Stock";
            // 
            // Product_Mgmt_Panel
            // 
            this.Product_Mgmt_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Product_Mgmt_Panel.Controls.Add(this.Header_Panel);
            this.Product_Mgmt_Panel.Controls.Add(this.Search_Input);
            this.Product_Mgmt_Panel.Controls.Add(this.Edit_Button);
            this.Product_Mgmt_Panel.Controls.Add(this.Delete_Button);
            this.Product_Mgmt_Panel.Controls.Add(this.Create_Button);
            this.Product_Mgmt_Panel.Controls.Add(this.Search_Label);
            this.Product_Mgmt_Panel.Controls.Add(this.DataTable);
            this.Product_Mgmt_Panel.Controls.Add(this.TotalProducts_DB);
            this.Product_Mgmt_Panel.Controls.Add(this.InStock_DB);
            this.Product_Mgmt_Panel.Controls.Add(this.OutOfStock_DB);
            this.Product_Mgmt_Panel.Controls.Add(this.LowStock_DB);
            this.Product_Mgmt_Panel.Location = new System.Drawing.Point(0, 0);
            this.Product_Mgmt_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Product_Mgmt_Panel.Name = "Product_Mgmt_Panel";
            this.Product_Mgmt_Panel.Size = new System.Drawing.Size(1262, 678);
            this.Product_Mgmt_Panel.TabIndex = 7;
            // 
            // Edit_Button
            // 
            this.Edit_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit_Button.Image = ((System.Drawing.Image)(resources.GetObject("Edit_Button.Image")));
            this.Edit_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Edit_Button.Location = new System.Drawing.Point(396, 158);
            this.Edit_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Edit_Button.Size = new System.Drawing.Size(105, 37);
            this.Edit_Button.TabIndex = 9;
            this.Edit_Button.Text = "Edit";
            this.Edit_Button.UseVisualStyleBackColor = true;
            this.Edit_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_Button.Image = ((System.Drawing.Image)(resources.GetObject("Delete_Button.Image")));
            this.Delete_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete_Button.Location = new System.Drawing.Point(531, 158);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Delete_Button.Size = new System.Drawing.Size(128, 37);
            this.Delete_Button.TabIndex = 10;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.UseVisualStyleBackColor = true;
            // 
            // Create_Button
            // 
            this.Create_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_Button.Image = ((System.Drawing.Image)(resources.GetObject("Create_Button.Image")));
            this.Create_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Create_Button.Location = new System.Drawing.Point(258, 158);
            this.Create_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Create_Button.Name = "Create_Button";
            this.Create_Button.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.Create_Button.Size = new System.Drawing.Size(112, 37);
            this.Create_Button.TabIndex = 8;
            this.Create_Button.Text = "Create";
            this.Create_Button.UseVisualStyleBackColor = true;
            this.Create_Button.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // OutOfStock_DB
            // 
            this.OutOfStock_DB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OutOfStock_DB.Controls.Add(this.OOS_Count);
            this.OutOfStock_DB.Controls.Add(this.OOS_Label);
            this.OutOfStock_DB.Controls.Add(this.OOS_Color);
            this.OutOfStock_DB.Location = new System.Drawing.Point(986, 78);
            this.OutOfStock_DB.Margin = new System.Windows.Forms.Padding(2);
            this.OutOfStock_DB.Name = "OutOfStock_DB";
            this.OutOfStock_DB.Size = new System.Drawing.Size(200, 63);
            this.OutOfStock_DB.TabIndex = 24;
            // 
            // OOS_Count
            // 
            this.OOS_Count.AutoSize = true;
            this.OOS_Count.Font = new System.Drawing.Font("Malgun Gothic", 16.2F);
            this.OOS_Count.Location = new System.Drawing.Point(14, 27);
            this.OOS_Count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OOS_Count.Name = "OOS_Count";
            this.OOS_Count.Size = new System.Drawing.Size(25, 30);
            this.OOS_Count.TabIndex = 4;
            this.OOS_Count.Text = "0";
            // 
            // OOS_Label
            // 
            this.OOS_Label.AutoSize = true;
            this.OOS_Label.Font = new System.Drawing.Font("Malgun Gothic", 7.8F);
            this.OOS_Label.Location = new System.Drawing.Point(16, 10);
            this.OOS_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OOS_Label.Name = "OOS_Label";
            this.OOS_Label.Size = new System.Drawing.Size(74, 13);
            this.OOS_Label.TabIndex = 2;
            this.OOS_Label.Text = "Out Of Stock";
            // 
            // OOS_Color
            // 
            this.OOS_Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OOS_Color.Location = new System.Drawing.Point(0, 0);
            this.OOS_Color.Margin = new System.Windows.Forms.Padding(2);
            this.OOS_Color.Name = "OOS_Color";
            this.OOS_Color.Size = new System.Drawing.Size(8, 63);
            this.OOS_Color.TabIndex = 5;
            // 
            // Product_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.Product_Mgmt_Panel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Product_Information";
            this.Text = "Product Information";
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.TotalProducts_DB.ResumeLayout(false);
            this.TotalProducts_DB.PerformLayout();
            this.InStock_DB.ResumeLayout(false);
            this.InStock_DB.PerformLayout();
            this.SidePanel.ResumeLayout(false);
            this.Logo_Panel.ResumeLayout(false);
            this.Logo_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DMMMSU_Logo)).EndInit();
            this.Header_Panel.ResumeLayout(false);
            this.Header_Panel.PerformLayout();
            this.LowStock_DB.ResumeLayout(false);
            this.LowStock_DB.PerformLayout();
            this.Product_Mgmt_Panel.ResumeLayout(false);
            this.Product_Mgmt_Panel.PerformLayout();
            this.OutOfStock_DB.ResumeLayout(false);
            this.OutOfStock_DB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.Label TP_Label;
        private System.Windows.Forms.Panel TotalProducts_DB;
        private System.Windows.Forms.Panel InStock_DB;
        private System.Windows.Forms.Label IS_Label;
        private System.Windows.Forms.Label TP_Counter;
        private System.Windows.Forms.Label IS_Counter;
        private System.Windows.Forms.Panel TP_Color;
        private System.Windows.Forms.Panel IS_Color;
        private System.Windows.Forms.Button Create_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Label Search_Label;
        private System.Windows.Forms.Panel SidePanel;
        private Guna.UI2.WinForms.Guna2Button ExitButton;
        private Guna.UI2.WinForms.Guna2Button Notification_Button;
        private Guna.UI2.WinForms.Guna2Button ProductManagement_Button;
        private Guna.UI2.WinForms.Guna2Button AdminDashboard_Button;
        private System.Windows.Forms.Panel Logo_Panel;
        private System.Windows.Forms.Label HiveStock;
        private System.Windows.Forms.PictureBox DMMMSU_Logo;
        private Guna.UI2.WinForms.Guna2TextBox Search_Input;
        private System.Windows.Forms.Panel Header_Panel;
        private System.Windows.Forms.Label MarketingCenter;
        private System.Windows.Forms.Panel LS_Color;
        private System.Windows.Forms.Panel LowStock_DB;
        private System.Windows.Forms.Label LS_Count;
        private System.Windows.Forms.Label LS_Label;
        private System.Windows.Forms.Panel Product_Mgmt_Panel;
        private System.Windows.Forms.Panel OutOfStock_DB;
        private System.Windows.Forms.Label OOS_Count;
        private System.Windows.Forms.Label OOS_Label;
        private System.Windows.Forms.Panel OOS_Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockStatus;
    }
}