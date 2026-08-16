namespace LogIn_HiveStock
{
    partial class PM_CreateProduct
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
            this.CPInfo_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.CPStatus_Dropdown = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CPStatus_Label = new System.Windows.Forms.Label();
            this.CPQuantity_Label = new System.Windows.Forms.Label();
            this.CPQuantity_UpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.CPPrice_Label = new System.Windows.Forms.Label();
            this.CPPrice_UpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.CPCancel_Button = new Guna.UI2.WinForms.Guna2Button();
            this.CPCreate_Button = new Guna.UI2.WinForms.Guna2Button();
            this.CPDescription_TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.CPDescription_Label = new System.Windows.Forms.Label();
            this.CPCategory_Dropdown = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CPProductName_Label = new System.Windows.Forms.Label();
            this.CPProductName_TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.CPCategory_Label = new System.Windows.Forms.Label();
            this.CPProductID_TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.CPProductID_Label = new System.Windows.Forms.Label();
            this.CreateProduct_Label = new System.Windows.Forms.Label();
            this.CPInfo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPQuantity_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPPrice_UpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // CPInfo_Panel
            // 
            this.CPInfo_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.CPInfo_Panel.Controls.Add(this.CPStatus_Dropdown);
            this.CPInfo_Panel.Controls.Add(this.CPStatus_Label);
            this.CPInfo_Panel.Controls.Add(this.CPQuantity_Label);
            this.CPInfo_Panel.Controls.Add(this.CPQuantity_UpDown);
            this.CPInfo_Panel.Controls.Add(this.CPPrice_Label);
            this.CPInfo_Panel.Controls.Add(this.CPPrice_UpDown);
            this.CPInfo_Panel.Controls.Add(this.CPCancel_Button);
            this.CPInfo_Panel.Controls.Add(this.CPCreate_Button);
            this.CPInfo_Panel.Controls.Add(this.CPDescription_TextBox);
            this.CPInfo_Panel.Controls.Add(this.CPDescription_Label);
            this.CPInfo_Panel.Controls.Add(this.CPCategory_Dropdown);
            this.CPInfo_Panel.Controls.Add(this.CPProductName_Label);
            this.CPInfo_Panel.Controls.Add(this.CPProductName_TextBox);
            this.CPInfo_Panel.Controls.Add(this.CPCategory_Label);
            this.CPInfo_Panel.Controls.Add(this.CPProductID_TextBox);
            this.CPInfo_Panel.Controls.Add(this.CPProductID_Label);
            this.CPInfo_Panel.Location = new System.Drawing.Point(-1, 67);
            this.CPInfo_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.CPInfo_Panel.Name = "CPInfo_Panel";
            this.CPInfo_Panel.Size = new System.Drawing.Size(618, 338);
            this.CPInfo_Panel.TabIndex = 1;
            // 
            // CPStatus_Dropdown
            // 
            this.CPStatus_Dropdown.BackColor = System.Drawing.Color.Transparent;
            this.CPStatus_Dropdown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPStatus_Dropdown.BorderRadius = 10;
            this.CPStatus_Dropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CPStatus_Dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPStatus_Dropdown.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPStatus_Dropdown.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPStatus_Dropdown.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPStatus_Dropdown.ForeColor = System.Drawing.Color.Black;
            this.CPStatus_Dropdown.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPStatus_Dropdown.ItemHeight = 30;
            this.CPStatus_Dropdown.Items.AddRange(new object[] {
            "Select Status",
            "On Stock",
            "Low Stock",
            "Out of Stock"});
            this.CPStatus_Dropdown.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPStatus_Dropdown.ItemsAppearance.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.CPStatus_Dropdown.Location = new System.Drawing.Point(455, 119);
            this.CPStatus_Dropdown.Margin = new System.Windows.Forms.Padding(2);
            this.CPStatus_Dropdown.Name = "CPStatus_Dropdown";
            this.CPStatus_Dropdown.ShadowDecoration.Depth = 0;
            this.CPStatus_Dropdown.Size = new System.Drawing.Size(128, 36);
            this.CPStatus_Dropdown.StartIndex = 0;
            this.CPStatus_Dropdown.TabIndex = 47;
            this.CPStatus_Dropdown.Tag = "";
            // 
            // CPStatus_Label
            // 
            this.CPStatus_Label.AutoSize = true;
            this.CPStatus_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPStatus_Label.ForeColor = System.Drawing.Color.DimGray;
            this.CPStatus_Label.Location = new System.Drawing.Point(411, 127);
            this.CPStatus_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPStatus_Label.Name = "CPStatus_Label";
            this.CPStatus_Label.Size = new System.Drawing.Size(44, 15);
            this.CPStatus_Label.TabIndex = 46;
            this.CPStatus_Label.Text = "Status";
            // 
            // CPQuantity_Label
            // 
            this.CPQuantity_Label.AutoSize = true;
            this.CPQuantity_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPQuantity_Label.ForeColor = System.Drawing.Color.DimGray;
            this.CPQuantity_Label.Location = new System.Drawing.Point(238, 127);
            this.CPQuantity_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPQuantity_Label.Name = "CPQuantity_Label";
            this.CPQuantity_Label.Size = new System.Drawing.Size(56, 15);
            this.CPQuantity_Label.TabIndex = 45;
            this.CPQuantity_Label.Text = "Quantity";
            // 
            // CPQuantity_UpDown
            // 
            this.CPQuantity_UpDown.BackColor = System.Drawing.Color.Transparent;
            this.CPQuantity_UpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPQuantity_UpDown.BorderRadius = 10;
            this.CPQuantity_UpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CPQuantity_UpDown.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPQuantity_UpDown.Location = new System.Drawing.Point(296, 118);
            this.CPQuantity_UpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CPQuantity_UpDown.Name = "CPQuantity_UpDown";
            this.CPQuantity_UpDown.Size = new System.Drawing.Size(102, 38);
            this.CPQuantity_UpDown.TabIndex = 44;
            this.CPQuantity_UpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPQuantity_UpDown.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            // 
            // CPPrice_Label
            // 
            this.CPPrice_Label.AutoSize = true;
            this.CPPrice_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPPrice_Label.ForeColor = System.Drawing.Color.DimGray;
            this.CPPrice_Label.Location = new System.Drawing.Point(70, 127);
            this.CPPrice_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPPrice_Label.Name = "CPPrice_Label";
            this.CPPrice_Label.Size = new System.Drawing.Size(35, 15);
            this.CPPrice_Label.TabIndex = 43;
            this.CPPrice_Label.Text = "Price";
            // 
            // CPPrice_UpDown
            // 
            this.CPPrice_UpDown.BackColor = System.Drawing.Color.Transparent;
            this.CPPrice_UpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPPrice_UpDown.BorderRadius = 10;
            this.CPPrice_UpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CPPrice_UpDown.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPPrice_UpDown.Location = new System.Drawing.Point(110, 118);
            this.CPPrice_UpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CPPrice_UpDown.Name = "CPPrice_UpDown";
            this.CPPrice_UpDown.Size = new System.Drawing.Size(117, 38);
            this.CPPrice_UpDown.TabIndex = 42;
            this.CPPrice_UpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPPrice_UpDown.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            // 
            // CPCancel_Button
            // 
            this.CPCancel_Button.BackColor = System.Drawing.Color.Transparent;
            this.CPCancel_Button.BorderRadius = 5;
            this.CPCancel_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CPCancel_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CPCancel_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CPCancel_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CPCancel_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CPCancel_Button.FillColor = System.Drawing.Color.Gray;
            this.CPCancel_Button.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPCancel_Button.ForeColor = System.Drawing.Color.Black;
            this.CPCancel_Button.HoverState.FillColor = System.Drawing.Color.Gray;
            this.CPCancel_Button.Location = new System.Drawing.Point(173, 277);
            this.CPCancel_Button.Name = "CPCancel_Button";
            this.CPCancel_Button.Size = new System.Drawing.Size(127, 36);
            this.CPCancel_Button.TabIndex = 37;
            this.CPCancel_Button.Text = "CANCEL";
            this.CPCancel_Button.Click += new System.EventHandler(this.CPCancel_Button_Click);
            // 
            // CPCreate_Button
            // 
            this.CPCreate_Button.BackColor = System.Drawing.Color.Transparent;
            this.CPCreate_Button.BorderRadius = 5;
            this.CPCreate_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CPCreate_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CPCreate_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CPCreate_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CPCreate_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CPCreate_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.CPCreate_Button.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPCreate_Button.ForeColor = System.Drawing.Color.Black;
            this.CPCreate_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.CPCreate_Button.Location = new System.Drawing.Point(314, 277);
            this.CPCreate_Button.Name = "CPCreate_Button";
            this.CPCreate_Button.Size = new System.Drawing.Size(127, 36);
            this.CPCreate_Button.TabIndex = 36;
            this.CPCreate_Button.Text = "CREATE";
            this.CPCreate_Button.Click += new System.EventHandler(this.CPCreate_Button_Click);
            // 
            // CPDescription_TextBox
            // 
            this.CPDescription_TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPDescription_TextBox.BorderRadius = 10;
            this.CPDescription_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CPDescription_TextBox.DefaultText = "";
            this.CPDescription_TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CPDescription_TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CPDescription_TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CPDescription_TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CPDescription_TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPDescription_TextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CPDescription_TextBox.ForeColor = System.Drawing.Color.Black;
            this.CPDescription_TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CPDescription_TextBox.Location = new System.Drawing.Point(110, 175);
            this.CPDescription_TextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CPDescription_TextBox.MaxLength = 200;
            this.CPDescription_TextBox.Multiline = true;
            this.CPDescription_TextBox.Name = "CPDescription_TextBox";
            this.CPDescription_TextBox.PlaceholderText = "";
            this.CPDescription_TextBox.SelectedText = "";
            this.CPDescription_TextBox.Size = new System.Drawing.Size(463, 80);
            this.CPDescription_TextBox.TabIndex = 14;
            // 
            // CPDescription_Label
            // 
            this.CPDescription_Label.AutoSize = true;
            this.CPDescription_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPDescription_Label.ForeColor = System.Drawing.Color.DimGray;
            this.CPDescription_Label.Location = new System.Drawing.Point(34, 181);
            this.CPDescription_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPDescription_Label.Name = "CPDescription_Label";
            this.CPDescription_Label.Size = new System.Drawing.Size(73, 15);
            this.CPDescription_Label.TabIndex = 13;
            this.CPDescription_Label.Text = "Description";
            // 
            // CPCategory_Dropdown
            // 
            this.CPCategory_Dropdown.BackColor = System.Drawing.Color.Transparent;
            this.CPCategory_Dropdown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPCategory_Dropdown.BorderRadius = 10;
            this.CPCategory_Dropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CPCategory_Dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPCategory_Dropdown.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPCategory_Dropdown.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPCategory_Dropdown.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPCategory_Dropdown.ForeColor = System.Drawing.Color.Black;
            this.CPCategory_Dropdown.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPCategory_Dropdown.ItemHeight = 28;
            this.CPCategory_Dropdown.Items.AddRange(new object[] {
            "Choose Category",
            "Books",
            "ID Lace",
            "Uniform"});
            this.CPCategory_Dropdown.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPCategory_Dropdown.ItemsAppearance.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.CPCategory_Dropdown.Location = new System.Drawing.Point(442, 18);
            this.CPCategory_Dropdown.Margin = new System.Windows.Forms.Padding(2);
            this.CPCategory_Dropdown.Name = "CPCategory_Dropdown";
            this.CPCategory_Dropdown.ShadowDecoration.Depth = 0;
            this.CPCategory_Dropdown.Size = new System.Drawing.Size(148, 34);
            this.CPCategory_Dropdown.StartIndex = 0;
            this.CPCategory_Dropdown.TabIndex = 10;
            this.CPCategory_Dropdown.Tag = "";
            // 
            // CPProductName_Label
            // 
            this.CPProductName_Label.AutoSize = true;
            this.CPProductName_Label.BackColor = System.Drawing.Color.Transparent;
            this.CPProductName_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPProductName_Label.ForeColor = System.Drawing.Color.DimGray;
            this.CPProductName_Label.Location = new System.Drawing.Point(18, 76);
            this.CPProductName_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPProductName_Label.Name = "CPProductName_Label";
            this.CPProductName_Label.Size = new System.Drawing.Size(91, 15);
            this.CPProductName_Label.TabIndex = 9;
            this.CPProductName_Label.Text = "Product Name";
            // 
            // CPProductName_TextBox
            // 
            this.CPProductName_TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPProductName_TextBox.BorderRadius = 10;
            this.CPProductName_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CPProductName_TextBox.DefaultText = "";
            this.CPProductName_TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CPProductName_TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CPProductName_TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CPProductName_TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CPProductName_TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPProductName_TextBox.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPProductName_TextBox.ForeColor = System.Drawing.Color.Black;
            this.CPProductName_TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPProductName_TextBox.Location = new System.Drawing.Point(110, 69);
            this.CPProductName_TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CPProductName_TextBox.MaxLength = 15;
            this.CPProductName_TextBox.Name = "CPProductName_TextBox";
            this.CPProductName_TextBox.PlaceholderText = "";
            this.CPProductName_TextBox.SelectedText = "";
            this.CPProductName_TextBox.Size = new System.Drawing.Size(252, 29);
            this.CPProductName_TextBox.TabIndex = 8;
            // 
            // CPCategory_Label
            // 
            this.CPCategory_Label.AutoSize = true;
            this.CPCategory_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPCategory_Label.ForeColor = System.Drawing.Color.DimGray;
            this.CPCategory_Label.Location = new System.Drawing.Point(382, 28);
            this.CPCategory_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPCategory_Label.Name = "CPCategory_Label";
            this.CPCategory_Label.Size = new System.Drawing.Size(60, 15);
            this.CPCategory_Label.TabIndex = 6;
            this.CPCategory_Label.Text = "Category";
            // 
            // CPProductID_TextBox
            // 
            this.CPProductID_TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.CPProductID_TextBox.BorderRadius = 10;
            this.CPProductID_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CPProductID_TextBox.DefaultText = "";
            this.CPProductID_TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CPProductID_TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CPProductID_TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CPProductID_TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CPProductID_TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPProductID_TextBox.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPProductID_TextBox.ForeColor = System.Drawing.Color.Black;
            this.CPProductID_TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.CPProductID_TextBox.Location = new System.Drawing.Point(110, 19);
            this.CPProductID_TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CPProductID_TextBox.MaxLength = 15;
            this.CPProductID_TextBox.Name = "CPProductID_TextBox";
            this.CPProductID_TextBox.PlaceholderText = "";
            this.CPProductID_TextBox.SelectedText = "";
            this.CPProductID_TextBox.Size = new System.Drawing.Size(252, 31);
            this.CPProductID_TextBox.TabIndex = 5;
            // 
            // CPProductID_Label
            // 
            this.CPProductID_Label.AutoSize = true;
            this.CPProductID_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPProductID_Label.ForeColor = System.Drawing.Color.DimGray;
            this.CPProductID_Label.Location = new System.Drawing.Point(38, 28);
            this.CPProductID_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPProductID_Label.Name = "CPProductID_Label";
            this.CPProductID_Label.Size = new System.Drawing.Size(69, 15);
            this.CPProductID_Label.TabIndex = 0;
            this.CPProductID_Label.Text = "Product ID";
            // 
            // CreateProduct_Label
            // 
            this.CreateProduct_Label.AutoSize = true;
            this.CreateProduct_Label.BackColor = System.Drawing.Color.Transparent;
            this.CreateProduct_Label.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateProduct_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.CreateProduct_Label.Location = new System.Drawing.Point(30, 17);
            this.CreateProduct_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CreateProduct_Label.Name = "CreateProduct_Label";
            this.CreateProduct_Label.Size = new System.Drawing.Size(225, 32);
            this.CreateProduct_Label.TabIndex = 8;
            this.CreateProduct_Label.Text = "CREATE PRODUCT";
            // 
            // PM_CreateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(616, 405);
            this.Controls.Add(this.CreateProduct_Label);
            this.Controls.Add(this.CPInfo_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PM_CreateProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.CPInfo_Panel.ResumeLayout(false);
            this.CPInfo_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPQuantity_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPPrice_UpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel CPInfo_Panel;
        private Guna.UI2.WinForms.Guna2ComboBox CPStatus_Dropdown;
        private System.Windows.Forms.Label CPStatus_Label;
        private System.Windows.Forms.Label CPQuantity_Label;
        private Guna.UI2.WinForms.Guna2NumericUpDown CPQuantity_UpDown;
        private System.Windows.Forms.Label CPPrice_Label;
        private Guna.UI2.WinForms.Guna2NumericUpDown CPPrice_UpDown;
        private Guna.UI2.WinForms.Guna2Button CPCancel_Button;
        private Guna.UI2.WinForms.Guna2Button CPCreate_Button;
        private Guna.UI2.WinForms.Guna2TextBox CPDescription_TextBox;
        private System.Windows.Forms.Label CPDescription_Label;
        private Guna.UI2.WinForms.Guna2ComboBox CPCategory_Dropdown;
        private System.Windows.Forms.Label CPProductName_Label;
        private Guna.UI2.WinForms.Guna2TextBox CPProductName_TextBox;
        private System.Windows.Forms.Label CPCategory_Label;
        private Guna.UI2.WinForms.Guna2TextBox CPProductID_TextBox;
        private System.Windows.Forms.Label CPProductID_Label;
        private System.Windows.Forms.Label CreateProduct_Label;
    }
}