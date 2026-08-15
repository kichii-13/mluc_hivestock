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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Header_Panel = new System.Windows.Forms.Panel();
            this.MarketingCenter = new System.Windows.Forms.Label();
            this.OrderManagement_Panel = new System.Windows.Forms.Panel();
            this.Complete_Button = new System.Windows.Forms.Button();
            this.View_Button = new System.Windows.Forms.Button();
            this.OMSearch_Input = new Guna.UI2.WinForms.Guna2TextBox();
            this.OMSearch_Label = new System.Windows.Forms.Label();
            this.OM_OrdersCompleted_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.OMOC_Color = new Guna.UI2.WinForms.Guna2Panel();
            this.OMOC_Counter = new System.Windows.Forms.Label();
            this.OMOC_Label = new System.Windows.Forms.Label();
            this.OM_PendingPickups_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.OMPP_Color = new Guna.UI2.WinForms.Guna2Panel();
            this.OMPP_Counter = new System.Windows.Forms.Label();
            this.OMPP_Label = new System.Windows.Forms.Label();
            this.OM_TotalOrders_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.OMTO_Color = new Guna.UI2.WinForms.Guna2Panel();
            this.OMTO_Counter = new System.Windows.Forms.Label();
            this.OMTO_Label = new System.Windows.Forms.Label();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Header_Panel.SuspendLayout();
            this.OrderManagement_Panel.SuspendLayout();
            this.OM_OrdersCompleted_Panel.SuspendLayout();
            this.OM_PendingPickups_Panel.SuspendLayout();
            this.OM_TotalOrders_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // Header_Panel
            // 
            this.Header_Panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Header_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.Header_Panel.Controls.Add(this.MarketingCenter);
            this.Header_Panel.Location = new System.Drawing.Point(185, 1);
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
            this.MarketingCenter.Size = new System.Drawing.Size(279, 32);
            this.MarketingCenter.TabIndex = 6;
            this.MarketingCenter.Text = "ORDER MANAGEMENT";
            // 
            // OrderManagement_Panel
            // 
            this.OrderManagement_Panel.BackColor = System.Drawing.Color.Transparent;
            this.OrderManagement_Panel.Controls.Add(this.Complete_Button);
            this.OrderManagement_Panel.Controls.Add(this.View_Button);
            this.OrderManagement_Panel.Controls.Add(this.OMSearch_Input);
            this.OrderManagement_Panel.Controls.Add(this.OMSearch_Label);
            this.OrderManagement_Panel.Controls.Add(this.OM_OrdersCompleted_Panel);
            this.OrderManagement_Panel.Controls.Add(this.OM_PendingPickups_Panel);
            this.OrderManagement_Panel.Controls.Add(this.OM_TotalOrders_Panel);
            this.OrderManagement_Panel.Controls.Add(this.DataTable);
            this.OrderManagement_Panel.Controls.Add(this.Header_Panel);
            this.OrderManagement_Panel.Location = new System.Drawing.Point(-3, -1);
            this.OrderManagement_Panel.Name = "OrderManagement_Panel";
            this.OrderManagement_Panel.Size = new System.Drawing.Size(1271, 682);
            this.OrderManagement_Panel.TabIndex = 7;
            // 
            // Complete_Button
            // 
            this.Complete_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Complete_Button.Image = global::LogIn_HiveStock.Properties.Resources.complete;
            this.Complete_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Complete_Button.Location = new System.Drawing.Point(398, 158);
            this.Complete_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Complete_Button.Name = "Complete_Button";
            this.Complete_Button.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Complete_Button.Size = new System.Drawing.Size(130, 37);
            this.Complete_Button.TabIndex = 35;
            this.Complete_Button.Text = "      Complete";
            this.Complete_Button.UseVisualStyleBackColor = true;
            // 
            // View_Button
            // 
            this.View_Button.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_Button.Image = global::LogIn_HiveStock.Properties.Resources.view;
            this.View_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.View_Button.Location = new System.Drawing.Point(258, 158);
            this.View_Button.Margin = new System.Windows.Forms.Padding(2);
            this.View_Button.Name = "View_Button";
            this.View_Button.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.View_Button.Size = new System.Drawing.Size(130, 37);
            this.View_Button.TabIndex = 34;
            this.View_Button.Text = "      View";
            this.View_Button.UseVisualStyleBackColor = true;
            // 
            // OMSearch_Input
            // 
            this.OMSearch_Input.BorderColor = System.Drawing.Color.DarkGray;
            this.OMSearch_Input.BorderRadius = 5;
            this.OMSearch_Input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OMSearch_Input.DefaultText = "";
            this.OMSearch_Input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.OMSearch_Input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.OMSearch_Input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OMSearch_Input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OMSearch_Input.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.OMSearch_Input.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OMSearch_Input.ForeColor = System.Drawing.Color.Black;
            this.OMSearch_Input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.OMSearch_Input.Location = new System.Drawing.Point(1010, 164);
            this.OMSearch_Input.Margin = new System.Windows.Forms.Padding(2);
            this.OMSearch_Input.Name = "OMSearch_Input";
            this.OMSearch_Input.PlaceholderText = "Orders";
            this.OMSearch_Input.SelectedText = "";
            this.OMSearch_Input.Size = new System.Drawing.Size(176, 27);
            this.OMSearch_Input.TabIndex = 33;
            // 
            // OMSearch_Label
            // 
            this.OMSearch_Label.AutoSize = true;
            this.OMSearch_Label.Location = new System.Drawing.Point(963, 170);
            this.OMSearch_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OMSearch_Label.Name = "OMSearch_Label";
            this.OMSearch_Label.Size = new System.Drawing.Size(41, 13);
            this.OMSearch_Label.TabIndex = 32;
            this.OMSearch_Label.Text = "Search";
            // 
            // OM_OrdersCompleted_Panel
            // 
            this.OM_OrdersCompleted_Panel.BorderRadius = 10;
            this.OM_OrdersCompleted_Panel.Controls.Add(this.OMOC_Color);
            this.OM_OrdersCompleted_Panel.Controls.Add(this.OMOC_Counter);
            this.OM_OrdersCompleted_Panel.Controls.Add(this.OMOC_Label);
            this.OM_OrdersCompleted_Panel.FillColor = System.Drawing.Color.Gainsboro;
            this.OM_OrdersCompleted_Panel.Location = new System.Drawing.Point(589, 78);
            this.OM_OrdersCompleted_Panel.Name = "OM_OrdersCompleted_Panel";
            this.OM_OrdersCompleted_Panel.Size = new System.Drawing.Size(270, 63);
            this.OM_OrdersCompleted_Panel.TabIndex = 31;
            // 
            // OMOC_Color
            // 
            this.OMOC_Color.BorderRadius = 5;
            this.OMOC_Color.CustomizableEdges.BottomRight = false;
            this.OMOC_Color.CustomizableEdges.TopRight = false;
            this.OMOC_Color.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.OMOC_Color.Location = new System.Drawing.Point(0, 0);
            this.OMOC_Color.Name = "OMOC_Color";
            this.OMOC_Color.Size = new System.Drawing.Size(13, 63);
            this.OMOC_Color.TabIndex = 0;
            // 
            // OMOC_Counter
            // 
            this.OMOC_Counter.AutoSize = true;
            this.OMOC_Counter.CausesValidation = false;
            this.OMOC_Counter.Font = new System.Drawing.Font("Malgun Gothic", 16.2F);
            this.OMOC_Counter.Location = new System.Drawing.Point(19, 26);
            this.OMOC_Counter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OMOC_Counter.Name = "OMOC_Counter";
            this.OMOC_Counter.Size = new System.Drawing.Size(25, 30);
            this.OMOC_Counter.TabIndex = 3;
            this.OMOC_Counter.Text = "0";
            // 
            // OMOC_Label
            // 
            this.OMOC_Label.AutoSize = true;
            this.OMOC_Label.CausesValidation = false;
            this.OMOC_Label.Font = new System.Drawing.Font("Malgun Gothic", 7.8F);
            this.OMOC_Label.Location = new System.Drawing.Point(21, 9);
            this.OMOC_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OMOC_Label.Name = "OMOC_Label";
            this.OMOC_Label.Size = new System.Drawing.Size(103, 13);
            this.OMOC_Label.TabIndex = 2;
            this.OMOC_Label.Text = "Orders Completed";
            // 
            // OM_PendingPickups_Panel
            // 
            this.OM_PendingPickups_Panel.BorderRadius = 10;
            this.OM_PendingPickups_Panel.Controls.Add(this.OMPP_Color);
            this.OM_PendingPickups_Panel.Controls.Add(this.OMPP_Counter);
            this.OM_PendingPickups_Panel.Controls.Add(this.OMPP_Label);
            this.OM_PendingPickups_Panel.FillColor = System.Drawing.Color.Gainsboro;
            this.OM_PendingPickups_Panel.Location = new System.Drawing.Point(916, 78);
            this.OM_PendingPickups_Panel.Name = "OM_PendingPickups_Panel";
            this.OM_PendingPickups_Panel.Size = new System.Drawing.Size(270, 63);
            this.OM_PendingPickups_Panel.TabIndex = 31;
            // 
            // OMPP_Color
            // 
            this.OMPP_Color.BorderRadius = 5;
            this.OMPP_Color.CustomizableEdges.BottomRight = false;
            this.OMPP_Color.CustomizableEdges.TopRight = false;
            this.OMPP_Color.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.OMPP_Color.Location = new System.Drawing.Point(0, 0);
            this.OMPP_Color.Name = "OMPP_Color";
            this.OMPP_Color.Size = new System.Drawing.Size(13, 63);
            this.OMPP_Color.TabIndex = 0;
            // 
            // OMPP_Counter
            // 
            this.OMPP_Counter.AutoSize = true;
            this.OMPP_Counter.CausesValidation = false;
            this.OMPP_Counter.Font = new System.Drawing.Font("Malgun Gothic", 16.2F);
            this.OMPP_Counter.Location = new System.Drawing.Point(19, 26);
            this.OMPP_Counter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OMPP_Counter.Name = "OMPP_Counter";
            this.OMPP_Counter.Size = new System.Drawing.Size(25, 30);
            this.OMPP_Counter.TabIndex = 3;
            this.OMPP_Counter.Text = "0";
            // 
            // OMPP_Label
            // 
            this.OMPP_Label.AutoSize = true;
            this.OMPP_Label.CausesValidation = false;
            this.OMPP_Label.Font = new System.Drawing.Font("Malgun Gothic", 7.8F);
            this.OMPP_Label.Location = new System.Drawing.Point(21, 9);
            this.OMPP_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OMPP_Label.Name = "OMPP_Label";
            this.OMPP_Label.Size = new System.Drawing.Size(90, 13);
            this.OMPP_Label.TabIndex = 2;
            this.OMPP_Label.Text = "Pending Pickups";
            // 
            // OM_TotalOrders_Panel
            // 
            this.OM_TotalOrders_Panel.BorderRadius = 10;
            this.OM_TotalOrders_Panel.Controls.Add(this.OMTO_Color);
            this.OM_TotalOrders_Panel.Controls.Add(this.OMTO_Counter);
            this.OM_TotalOrders_Panel.Controls.Add(this.OMTO_Label);
            this.OM_TotalOrders_Panel.FillColor = System.Drawing.Color.Gainsboro;
            this.OM_TotalOrders_Panel.Location = new System.Drawing.Point(258, 78);
            this.OM_TotalOrders_Panel.Name = "OM_TotalOrders_Panel";
            this.OM_TotalOrders_Panel.Size = new System.Drawing.Size(270, 63);
            this.OM_TotalOrders_Panel.TabIndex = 30;
            // 
            // OMTO_Color
            // 
            this.OMTO_Color.BorderRadius = 5;
            this.OMTO_Color.CustomizableEdges.BottomRight = false;
            this.OMTO_Color.CustomizableEdges.TopRight = false;
            this.OMTO_Color.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.OMTO_Color.Location = new System.Drawing.Point(0, 0);
            this.OMTO_Color.Name = "OMTO_Color";
            this.OMTO_Color.Size = new System.Drawing.Size(13, 63);
            this.OMTO_Color.TabIndex = 0;
            // 
            // OMTO_Counter
            // 
            this.OMTO_Counter.AutoSize = true;
            this.OMTO_Counter.CausesValidation = false;
            this.OMTO_Counter.Font = new System.Drawing.Font("Malgun Gothic", 16.2F);
            this.OMTO_Counter.Location = new System.Drawing.Point(19, 26);
            this.OMTO_Counter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OMTO_Counter.Name = "OMTO_Counter";
            this.OMTO_Counter.Size = new System.Drawing.Size(25, 30);
            this.OMTO_Counter.TabIndex = 3;
            this.OMTO_Counter.Text = "0";
            // 
            // OMTO_Label
            // 
            this.OMTO_Label.AutoSize = true;
            this.OMTO_Label.CausesValidation = false;
            this.OMTO_Label.Font = new System.Drawing.Font("Malgun Gothic", 7.8F);
            this.OMTO_Label.Location = new System.Drawing.Point(21, 9);
            this.OMTO_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OMTO_Label.Name = "OMTO_Label";
            this.OMTO_Label.Size = new System.Drawing.Size(72, 13);
            this.OMTO_Label.TabIndex = 2;
            this.OMTO_Label.Text = "Total Orders";
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
            this.Category,
            this.ProductID,
            this.ProductName,
            this.Description,
            this.Price,
            this.StockQuantity,
            this.OrderDate,
            this.StockStatus,
            this.Status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataTable.EnableHeadersVisualStyles = false;
            this.DataTable.GridColor = System.Drawing.Color.DarkOliveGreen;
            this.DataTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DataTable.Location = new System.Drawing.Point(258, 204);
            this.DataTable.Margin = new System.Windows.Forms.Padding(2);
            this.DataTable.Name = "DataTable";
            this.DataTable.ReadOnly = true;
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
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DataTable.RowTemplate.Height = 24;
            this.DataTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataTable.Size = new System.Drawing.Size(928, 446);
            this.DataTable.TabIndex = 7;
            this.DataTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataTable_CellContentClick);
            // 
            // Category
            // 
            this.Category.HeaderText = "Order No.";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 125;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "Student No.";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Width = 95;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Student Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 155;
            // 
            // Description
            // 
            this.Description.HeaderText = "Product";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 170;
            // 
            // Price
            // 
            this.Price.HeaderText = "Quantity";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 90;
            // 
            // StockQuantity
            // 
            this.StockQuantity.HeaderText = "Total Price";
            this.StockQuantity.MinimumWidth = 6;
            this.StockQuantity.Name = "StockQuantity";
            this.StockQuantity.ReadOnly = true;
            this.StockQuantity.Width = 120;
            // 
            // OrderDate
            // 
            this.OrderDate.HeaderText = "Order Date";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            this.OrderDate.Width = 120;
            // 
            // StockStatus
            // 
            this.StockStatus.HeaderText = "Receipt";
            this.StockStatus.MinimumWidth = 6;
            this.StockStatus.Name = "StockStatus";
            this.StockStatus.ReadOnly = true;
            this.StockStatus.Width = 160;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Notification_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.OrderManagement_Panel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Notification_Management";
            this.Text = "Notification Management";
            this.Header_Panel.ResumeLayout(false);
            this.Header_Panel.PerformLayout();
            this.OrderManagement_Panel.ResumeLayout(false);
            this.OrderManagement_Panel.PerformLayout();
            this.OM_OrdersCompleted_Panel.ResumeLayout(false);
            this.OM_OrdersCompleted_Panel.PerformLayout();
            this.OM_PendingPickups_Panel.ResumeLayout(false);
            this.OM_PendingPickups_Panel.PerformLayout();
            this.OM_TotalOrders_Panel.ResumeLayout(false);
            this.OM_TotalOrders_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Header_Panel;
        private System.Windows.Forms.Label MarketingCenter;
        private System.Windows.Forms.Panel OrderManagement_Panel;
        private System.Windows.Forms.DataGridView DataTable;
        private Guna.UI2.WinForms.Guna2TextBox OMSearch_Input;
        private System.Windows.Forms.Label OMSearch_Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button View_Button;
        private System.Windows.Forms.Button Complete_Button;
        private Guna.UI2.WinForms.Guna2Panel OM_OrdersCompleted_Panel;
        private Guna.UI2.WinForms.Guna2Panel OMOC_Color;
        private System.Windows.Forms.Label OMOC_Counter;
        private System.Windows.Forms.Label OMOC_Label;
        private Guna.UI2.WinForms.Guna2Panel OM_PendingPickups_Panel;
        private Guna.UI2.WinForms.Guna2Panel OMPP_Color;
        private System.Windows.Forms.Label OMPP_Counter;
        private System.Windows.Forms.Label OMPP_Label;
        private Guna.UI2.WinForms.Guna2Panel OM_TotalOrders_Panel;
        private Guna.UI2.WinForms.Guna2Panel OMTO_Color;
        private System.Windows.Forms.Label OMTO_Counter;
        private System.Windows.Forms.Label OMTO_Label;
    }
}