namespace LogIn_HiveStock
{
    partial class PM_EditProduct
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
            this.EditProduct_Label = new System.Windows.Forms.Label();
            this.EPStatus_Dropdown = new Guna.UI2.WinForms.Guna2ComboBox();
            this.EPStatus_Label = new System.Windows.Forms.Label();
            this.EPQuantity_Label = new System.Windows.Forms.Label();
            this.EPQuantity_UpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.EPPrice_Label = new System.Windows.Forms.Label();
            this.EPPrice_UpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.EPCancel_Button = new Guna.UI2.WinForms.Guna2Button();
            this.EPCreate_Button = new Guna.UI2.WinForms.Guna2Button();
            this.EPDescription_TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.EPDescription_Label = new System.Windows.Forms.Label();
            this.EPCategory_Dropdown = new Guna.UI2.WinForms.Guna2ComboBox();
            this.EPProductName_Label = new System.Windows.Forms.Label();
            this.EPProductName_TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.EPCategory_Label = new System.Windows.Forms.Label();
            this.EPProductID_TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.EPInfo_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.EPProductID_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EPQuantity_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPPrice_UpDown)).BeginInit();
            this.EPInfo_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditProduct_Label
            // 
            this.EditProduct_Label.AutoSize = true;
            this.EditProduct_Label.BackColor = System.Drawing.Color.Transparent;
            this.EditProduct_Label.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditProduct_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.EditProduct_Label.Location = new System.Drawing.Point(30, 17);
            this.EditProduct_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EditProduct_Label.Name = "EditProduct_Label";
            this.EditProduct_Label.Size = new System.Drawing.Size(189, 32);
            this.EditProduct_Label.TabIndex = 10;
            this.EditProduct_Label.Text = "EDIT PRODUCT";
            // 
            // EPStatus_Dropdown
            // 
            this.EPStatus_Dropdown.BackColor = System.Drawing.Color.Transparent;
            this.EPStatus_Dropdown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPStatus_Dropdown.BorderRadius = 10;
            this.EPStatus_Dropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.EPStatus_Dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EPStatus_Dropdown.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPStatus_Dropdown.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPStatus_Dropdown.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPStatus_Dropdown.ForeColor = System.Drawing.Color.Black;
            this.EPStatus_Dropdown.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPStatus_Dropdown.ItemHeight = 30;
            this.EPStatus_Dropdown.Items.AddRange(new object[] {
            "Select Status",
            "On Stock",
            "Low Stock",
            "Out of Stock"});
            this.EPStatus_Dropdown.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPStatus_Dropdown.ItemsAppearance.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.EPStatus_Dropdown.Location = new System.Drawing.Point(451, 119);
            this.EPStatus_Dropdown.Margin = new System.Windows.Forms.Padding(2);
            this.EPStatus_Dropdown.Name = "EPStatus_Dropdown";
            this.EPStatus_Dropdown.ShadowDecoration.Depth = 0;
            this.EPStatus_Dropdown.Size = new System.Drawing.Size(128, 36);
            this.EPStatus_Dropdown.StartIndex = 0;
            this.EPStatus_Dropdown.TabIndex = 47;
            this.EPStatus_Dropdown.Tag = "";
            // 
            // EPStatus_Label
            // 
            this.EPStatus_Label.AutoSize = true;
            this.EPStatus_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPStatus_Label.ForeColor = System.Drawing.Color.DimGray;
            this.EPStatus_Label.Location = new System.Drawing.Point(407, 127);
            this.EPStatus_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EPStatus_Label.Name = "EPStatus_Label";
            this.EPStatus_Label.Size = new System.Drawing.Size(44, 15);
            this.EPStatus_Label.TabIndex = 46;
            this.EPStatus_Label.Text = "Status";
            // 
            // EPQuantity_Label
            // 
            this.EPQuantity_Label.AutoSize = true;
            this.EPQuantity_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPQuantity_Label.ForeColor = System.Drawing.Color.DimGray;
            this.EPQuantity_Label.Location = new System.Drawing.Point(234, 127);
            this.EPQuantity_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EPQuantity_Label.Name = "EPQuantity_Label";
            this.EPQuantity_Label.Size = new System.Drawing.Size(56, 15);
            this.EPQuantity_Label.TabIndex = 45;
            this.EPQuantity_Label.Text = "Quantity";
            // 
            // EPQuantity_UpDown
            // 
            this.EPQuantity_UpDown.BackColor = System.Drawing.Color.Transparent;
            this.EPQuantity_UpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPQuantity_UpDown.BorderRadius = 10;
            this.EPQuantity_UpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EPQuantity_UpDown.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPQuantity_UpDown.Location = new System.Drawing.Point(292, 118);
            this.EPQuantity_UpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.EPQuantity_UpDown.Name = "EPQuantity_UpDown";
            this.EPQuantity_UpDown.Size = new System.Drawing.Size(102, 38);
            this.EPQuantity_UpDown.TabIndex = 44;
            this.EPQuantity_UpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPQuantity_UpDown.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            // 
            // EPPrice_Label
            // 
            this.EPPrice_Label.AutoSize = true;
            this.EPPrice_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPPrice_Label.ForeColor = System.Drawing.Color.DimGray;
            this.EPPrice_Label.Location = new System.Drawing.Point(66, 127);
            this.EPPrice_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EPPrice_Label.Name = "EPPrice_Label";
            this.EPPrice_Label.Size = new System.Drawing.Size(35, 15);
            this.EPPrice_Label.TabIndex = 43;
            this.EPPrice_Label.Text = "Price";
            // 
            // EPPrice_UpDown
            // 
            this.EPPrice_UpDown.BackColor = System.Drawing.Color.Transparent;
            this.EPPrice_UpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPPrice_UpDown.BorderRadius = 10;
            this.EPPrice_UpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EPPrice_UpDown.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPPrice_UpDown.Location = new System.Drawing.Point(106, 118);
            this.EPPrice_UpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.EPPrice_UpDown.Name = "EPPrice_UpDown";
            this.EPPrice_UpDown.Size = new System.Drawing.Size(117, 38);
            this.EPPrice_UpDown.TabIndex = 42;
            this.EPPrice_UpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPPrice_UpDown.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            // 
            // EPCancel_Button
            // 
            this.EPCancel_Button.BackColor = System.Drawing.Color.Transparent;
            this.EPCancel_Button.BorderRadius = 5;
            this.EPCancel_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EPCancel_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EPCancel_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EPCancel_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EPCancel_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EPCancel_Button.FillColor = System.Drawing.Color.Gray;
            this.EPCancel_Button.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPCancel_Button.ForeColor = System.Drawing.Color.Black;
            this.EPCancel_Button.HoverState.FillColor = System.Drawing.Color.Gray;
            this.EPCancel_Button.Location = new System.Drawing.Point(169, 277);
            this.EPCancel_Button.Name = "EPCancel_Button";
            this.EPCancel_Button.Size = new System.Drawing.Size(127, 36);
            this.EPCancel_Button.TabIndex = 37;
            this.EPCancel_Button.Text = "CANCEL";
            this.EPCancel_Button.Click += new System.EventHandler(this.EPCancel_Button_Click);
            // 
            // EPCreate_Button
            // 
            this.EPCreate_Button.BackColor = System.Drawing.Color.Transparent;
            this.EPCreate_Button.BorderRadius = 5;
            this.EPCreate_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EPCreate_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EPCreate_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EPCreate_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EPCreate_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EPCreate_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.EPCreate_Button.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPCreate_Button.ForeColor = System.Drawing.Color.Black;
            this.EPCreate_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(176)))), ((int)(((byte)(40)))));
            this.EPCreate_Button.Location = new System.Drawing.Point(310, 277);
            this.EPCreate_Button.Name = "EPCreate_Button";
            this.EPCreate_Button.Size = new System.Drawing.Size(127, 36);
            this.EPCreate_Button.TabIndex = 36;
            this.EPCreate_Button.Text = "CREATE";
            this.EPCreate_Button.Click += new System.EventHandler(this.EPCreate_Button_Click);
            // 
            // EPDescription_TextBox
            // 
            this.EPDescription_TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPDescription_TextBox.BorderRadius = 10;
            this.EPDescription_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EPDescription_TextBox.DefaultText = "";
            this.EPDescription_TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EPDescription_TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EPDescription_TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EPDescription_TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EPDescription_TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPDescription_TextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EPDescription_TextBox.ForeColor = System.Drawing.Color.Black;
            this.EPDescription_TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EPDescription_TextBox.Location = new System.Drawing.Point(106, 175);
            this.EPDescription_TextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.EPDescription_TextBox.MaxLength = 200;
            this.EPDescription_TextBox.Multiline = true;
            this.EPDescription_TextBox.Name = "EPDescription_TextBox";
            this.EPDescription_TextBox.PlaceholderText = "";
            this.EPDescription_TextBox.SelectedText = "";
            this.EPDescription_TextBox.Size = new System.Drawing.Size(463, 80);
            this.EPDescription_TextBox.TabIndex = 14;
            // 
            // EPDescription_Label
            // 
            this.EPDescription_Label.AutoSize = true;
            this.EPDescription_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPDescription_Label.ForeColor = System.Drawing.Color.DimGray;
            this.EPDescription_Label.Location = new System.Drawing.Point(30, 181);
            this.EPDescription_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EPDescription_Label.Name = "EPDescription_Label";
            this.EPDescription_Label.Size = new System.Drawing.Size(73, 15);
            this.EPDescription_Label.TabIndex = 13;
            this.EPDescription_Label.Text = "Description";
            // 
            // EPCategory_Dropdown
            // 
            this.EPCategory_Dropdown.BackColor = System.Drawing.Color.Transparent;
            this.EPCategory_Dropdown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPCategory_Dropdown.BorderRadius = 10;
            this.EPCategory_Dropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.EPCategory_Dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EPCategory_Dropdown.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPCategory_Dropdown.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPCategory_Dropdown.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPCategory_Dropdown.ForeColor = System.Drawing.Color.Black;
            this.EPCategory_Dropdown.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPCategory_Dropdown.ItemHeight = 28;
            this.EPCategory_Dropdown.Items.AddRange(new object[] {
            "Choose Category",
            "Books",
            "ID Lace",
            "Uniform"});
            this.EPCategory_Dropdown.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPCategory_Dropdown.ItemsAppearance.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.EPCategory_Dropdown.Location = new System.Drawing.Point(438, 18);
            this.EPCategory_Dropdown.Margin = new System.Windows.Forms.Padding(2);
            this.EPCategory_Dropdown.Name = "EPCategory_Dropdown";
            this.EPCategory_Dropdown.ShadowDecoration.Depth = 0;
            this.EPCategory_Dropdown.Size = new System.Drawing.Size(148, 34);
            this.EPCategory_Dropdown.StartIndex = 0;
            this.EPCategory_Dropdown.TabIndex = 10;
            this.EPCategory_Dropdown.Tag = "";
            // 
            // EPProductName_Label
            // 
            this.EPProductName_Label.AutoSize = true;
            this.EPProductName_Label.BackColor = System.Drawing.Color.Transparent;
            this.EPProductName_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPProductName_Label.ForeColor = System.Drawing.Color.DimGray;
            this.EPProductName_Label.Location = new System.Drawing.Point(14, 76);
            this.EPProductName_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EPProductName_Label.Name = "EPProductName_Label";
            this.EPProductName_Label.Size = new System.Drawing.Size(91, 15);
            this.EPProductName_Label.TabIndex = 9;
            this.EPProductName_Label.Text = "Product Name";
            // 
            // EPProductName_TextBox
            // 
            this.EPProductName_TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPProductName_TextBox.BorderRadius = 10;
            this.EPProductName_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EPProductName_TextBox.DefaultText = "";
            this.EPProductName_TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EPProductName_TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EPProductName_TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EPProductName_TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EPProductName_TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPProductName_TextBox.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPProductName_TextBox.ForeColor = System.Drawing.Color.Black;
            this.EPProductName_TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPProductName_TextBox.Location = new System.Drawing.Point(106, 69);
            this.EPProductName_TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EPProductName_TextBox.MaxLength = 15;
            this.EPProductName_TextBox.Name = "EPProductName_TextBox";
            this.EPProductName_TextBox.PlaceholderText = "";
            this.EPProductName_TextBox.SelectedText = "";
            this.EPProductName_TextBox.Size = new System.Drawing.Size(252, 29);
            this.EPProductName_TextBox.TabIndex = 8;
            // 
            // EPCategory_Label
            // 
            this.EPCategory_Label.AutoSize = true;
            this.EPCategory_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPCategory_Label.ForeColor = System.Drawing.Color.DimGray;
            this.EPCategory_Label.Location = new System.Drawing.Point(378, 28);
            this.EPCategory_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EPCategory_Label.Name = "EPCategory_Label";
            this.EPCategory_Label.Size = new System.Drawing.Size(60, 15);
            this.EPCategory_Label.TabIndex = 6;
            this.EPCategory_Label.Text = "Category";
            // 
            // EPProductID_TextBox
            // 
            this.EPProductID_TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.EPProductID_TextBox.BorderRadius = 10;
            this.EPProductID_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EPProductID_TextBox.DefaultText = "";
            this.EPProductID_TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EPProductID_TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EPProductID_TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EPProductID_TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EPProductID_TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPProductID_TextBox.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPProductID_TextBox.ForeColor = System.Drawing.Color.Black;
            this.EPProductID_TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(73)))));
            this.EPProductID_TextBox.Location = new System.Drawing.Point(106, 19);
            this.EPProductID_TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EPProductID_TextBox.MaxLength = 15;
            this.EPProductID_TextBox.Name = "EPProductID_TextBox";
            this.EPProductID_TextBox.PlaceholderText = "";
            this.EPProductID_TextBox.SelectedText = "";
            this.EPProductID_TextBox.Size = new System.Drawing.Size(252, 31);
            this.EPProductID_TextBox.TabIndex = 5;
            // 
            // EPInfo_Panel
            // 
            this.EPInfo_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(227)))));
            this.EPInfo_Panel.Controls.Add(this.EPStatus_Dropdown);
            this.EPInfo_Panel.Controls.Add(this.EPStatus_Label);
            this.EPInfo_Panel.Controls.Add(this.EPQuantity_Label);
            this.EPInfo_Panel.Controls.Add(this.EPQuantity_UpDown);
            this.EPInfo_Panel.Controls.Add(this.EPPrice_Label);
            this.EPInfo_Panel.Controls.Add(this.EPPrice_UpDown);
            this.EPInfo_Panel.Controls.Add(this.EPCancel_Button);
            this.EPInfo_Panel.Controls.Add(this.EPCreate_Button);
            this.EPInfo_Panel.Controls.Add(this.EPDescription_TextBox);
            this.EPInfo_Panel.Controls.Add(this.EPDescription_Label);
            this.EPInfo_Panel.Controls.Add(this.EPCategory_Dropdown);
            this.EPInfo_Panel.Controls.Add(this.EPProductName_Label);
            this.EPInfo_Panel.Controls.Add(this.EPProductName_TextBox);
            this.EPInfo_Panel.Controls.Add(this.EPCategory_Label);
            this.EPInfo_Panel.Controls.Add(this.EPProductID_TextBox);
            this.EPInfo_Panel.Controls.Add(this.EPProductID_Label);
            this.EPInfo_Panel.Location = new System.Drawing.Point(5, 70);
            this.EPInfo_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.EPInfo_Panel.Name = "EPInfo_Panel";
            this.EPInfo_Panel.Size = new System.Drawing.Size(606, 327);
            this.EPInfo_Panel.TabIndex = 9;
            // 
            // EPProductID_Label
            // 
            this.EPProductID_Label.AutoSize = true;
            this.EPProductID_Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPProductID_Label.ForeColor = System.Drawing.Color.DimGray;
            this.EPProductID_Label.Location = new System.Drawing.Point(34, 28);
            this.EPProductID_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EPProductID_Label.Name = "EPProductID_Label";
            this.EPProductID_Label.Size = new System.Drawing.Size(69, 15);
            this.EPProductID_Label.TabIndex = 0;
            this.EPProductID_Label.Text = "Product ID";
            // 
            // PM_EditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(77)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(616, 405);
            this.Controls.Add(this.EditProduct_Label);
            this.Controls.Add(this.EPInfo_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PM_EditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.EPQuantity_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPPrice_UpDown)).EndInit();
            this.EPInfo_Panel.ResumeLayout(false);
            this.EPInfo_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EditProduct_Label;
        private Guna.UI2.WinForms.Guna2ComboBox EPStatus_Dropdown;
        private System.Windows.Forms.Label EPStatus_Label;
        private System.Windows.Forms.Label EPQuantity_Label;
        private Guna.UI2.WinForms.Guna2NumericUpDown EPQuantity_UpDown;
        private System.Windows.Forms.Label EPPrice_Label;
        private Guna.UI2.WinForms.Guna2NumericUpDown EPPrice_UpDown;
        private Guna.UI2.WinForms.Guna2Button EPCancel_Button;
        private Guna.UI2.WinForms.Guna2Button EPCreate_Button;
        private Guna.UI2.WinForms.Guna2TextBox EPDescription_TextBox;
        private System.Windows.Forms.Label EPDescription_Label;
        private Guna.UI2.WinForms.Guna2ComboBox EPCategory_Dropdown;
        private System.Windows.Forms.Label EPProductName_Label;
        private Guna.UI2.WinForms.Guna2TextBox EPProductName_TextBox;
        private System.Windows.Forms.Label EPCategory_Label;
        private Guna.UI2.WinForms.Guna2TextBox EPProductID_TextBox;
        private Guna.UI2.WinForms.Guna2Panel EPInfo_Panel;
        private System.Windows.Forms.Label EPProductID_Label;
    }
}