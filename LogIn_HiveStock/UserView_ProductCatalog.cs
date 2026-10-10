using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // Required for ConfigurationManager
using MySqlConnector;        // Matches providerName="MySqlConnector" from App.config
using Guna.UI2.WinForms;

namespace LogIn_HiveStock
{
    public partial class UserView_ProductCatalog : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        // Native Win32 API to strictly force-hide the horizontal scrollbar
        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        private const int SB_HORZ = 0;

        private class ProductData
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string StockStatus { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string ContainerName { get; set; }
            public Image ProductImage { get; set; }
            public int StockQty { get; set; }
        }

        private class RestockNotificationData
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public DateTime? NotifiedAt { get; set; }
            public bool IsRead { get; set; }
        }

        private Dictionary<int, ProductData> productsCache = new Dictionary<int, ProductData>();

        // Store original Y positions and panel height from Designer layout
        private int booksOriginalY = 10;
        private int booksOriginalHeight = 300;
        private int idLaceOriginalY = 350;
        private int uniformOriginalY = 700;
        private int panelOriginalX = 10;

        public UserView_ProductCatalog()
        {
            InitializeComponent();
            this.Load += UserView_ProductCatalog_Load;

            if (Filter_Dropdown != null)
                Filter_Dropdown.SelectedIndexChanged += Filter_Dropdown_SelectedIndexChanged;

            Control[] searchCtrls = this.Controls.Find("Search_Input", true);
            if (searchCtrls.Length > 0)
            {
                searchCtrls[0].TextChanged += Search_Input_TextChanged;
                searchCtrls[0].KeyDown += Search_Input_KeyDown;
            }
        }

        private void UserView_ProductCatalog_Load(object sender, EventArgs e)
        {
            // Capture initial X, Y coordinates, and height set in Designer
            if (Books_Panel != null)
            {
                booksOriginalY = Books_Panel.Top;
                booksOriginalHeight = Books_Panel.Height;
                panelOriginalX = Books_Panel.Left;
            }
            if (IDLace_Panel != null) idLaceOriginalY = IDLace_Panel.Top;
            if (Uniform_Panel != null) uniformOriginalY = Uniform_Panel.Top;

            ConfigurePanels();
            SetupFilterDropdown();
            LoadProductData();

            // Pre-load notifications and sync notification bell icon state
            RefreshNotifications();
        }

        private void ConfigurePanels()
        {
            // Lock MainScrollPanel vertical-only scrolling
            if (MainScrollPanel != null)
            {
                MainScrollPanel.AutoScroll = true;
                MainScrollPanel.HorizontalScroll.Enabled = false;
                MainScrollPanel.HorizontalScroll.Visible = false;
                MainScrollPanel.Layout += SuppressHorizontalScroll;
            }

            // Lock Notif_Panel vertical-only scrolling
            if (Notif_Panel != null)
            {
                Notif_Panel.AutoScroll = true;
                Notif_Panel.HorizontalScroll.Enabled = false;
                Notif_Panel.HorizontalScroll.Visible = false;
                Notif_Panel.Layout += SuppressHorizontalScroll;
            }

            // Sub FlowLayoutPanels setup
            FlowLayoutPanel[] categoryPanels = new FlowLayoutPanel[] { Books_Panel, IDLace_Panel, Uniform_Panel };
            foreach (var panel in categoryPanels)
            {
                if (panel != null)
                {
                    panel.WrapContents = true;
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoScroll = false; // Disable panel auto-scroll so it flows inside MainScrollPanel

                    // Force disable horizontal scroll properties
                    panel.HorizontalScroll.Maximum = 0;
                    panel.HorizontalScroll.Enabled = false;
                    panel.HorizontalScroll.Visible = false;

                    // Attach layout events to suppress native scrollbar
                    panel.Layout += SuppressHorizontalScroll;
                }
            }
        }

        private void SuppressHorizontalScroll(object sender, LayoutEventArgs e)
        {
            if (sender is Control ctrl && ctrl.IsHandleCreated)
            {
                ShowScrollBar(ctrl.Handle, SB_HORZ, false);
            }
        }

        private void SetupFilterDropdown()
        {
            if (Filter_Dropdown == null) return;

            Filter_Dropdown.Items.Clear();
            Filter_Dropdown.Items.Add("No Filter");
            Filter_Dropdown.Items.Add("Books");
            Filter_Dropdown.Items.Add("ID Lace");
            Filter_Dropdown.Items.Add("Uniform");

            Filter_Dropdown.SelectedIndex = 0;
        }

        // Product id -> the card the designer made for it.
        private static readonly Dictionary<int, string> fixedCards = new Dictionary<int, string>
        {
            { 12, "Book1_Container" }, { 7, "Book2_Container" }, { 6, "Book3_Container" }, { 5, "Book4_Container" },
            { 4, "Book5_Container" }, { 3, "Book6_Container" }, { 2, "Book7_Container" }, { 1, "Book8_Container" },
            { 8, "ID1_Container" }, { 9, "ID2_Container" }, { 10, "UnivGala_Container" }, { 11, "UnifPathFit_Container" }
        };

        // Hides the fixed cards of products that were deleted, and builds cards for new products.
        private void SyncCardsWithDatabase()
        {
            bool changed = false;

            foreach (KeyValuePair<int, string> pair in fixedCards)
            {
                if (productsCache.ContainsKey(pair.Key)) continue;

                Control[] found = this.Controls.Find(pair.Value, true);
                if (found.Length > 0)
                {
                    found[0].Visible = false;
                    changed = true;
                }
            }

            foreach (KeyValuePair<int, ProductData> item in productsCache.OrderBy(k => k.Key))
            {
                if (fixedCards.ContainsKey(item.Key)) continue;

                int id = item.Key;
                FlowLayoutPanel target = Books_Panel;
                if (item.Value.CategoryId == 2) target = IDLace_Panel;
                else if (item.Value.CategoryId == 3) target = Uniform_Panel;
                if (target == null) continue;

                Guna2ContainerControl card = BuildProductCard(id);
                target.Controls.Add(card);   // it must be on the form before it can be filled in

                BindProductCard(id, card.Name, "Dyn" + id + "_Image", "Dyn" + id + "Title_Label",
                                "Dyn" + id + "Info_Label", "DynStock" + id + "_Status",
                                "DynPricePeso" + id + "_Label", "DynATC" + id + "_Button",
                                "DynNotify" + id + "_Button");
                changed = true;
            }

            if (changed) RelayoutCategoryPanels();
        }

        // The three sections have fixed positions, so stack them again after the card count changed.
        private void RelayoutCategoryPanels()
        {
            FlowLayoutPanel[] panels = { Books_Panel, IDLace_Panel, Uniform_Panel };
            foreach (FlowLayoutPanel panel in panels)
            {
                if (panel == null) continue;

                panel.PerformLayout();
                List<Control> shown = panel.Controls.Cast<Control>().Where(c => c.Visible).ToList();
                if (shown.Count > 0)
                    panel.Height = shown.Max(c => c.Bottom) + 10 + panel.Padding.Bottom;
            }

            if (Books_Panel != null && IDLace_Panel != null) IDLace_Panel.Top = Books_Panel.Bottom;
            if (IDLace_Panel != null && Uniform_Panel != null) Uniform_Panel.Top = IDLace_Panel.Bottom;

            // The filter code puts the sections back to these remembered values.
            if (Books_Panel != null) booksOriginalHeight = Books_Panel.Height;
            if (IDLace_Panel != null) idLaceOriginalY = IDLace_Panel.Top;
            if (Uniform_Panel != null) uniformOriginalY = Uniform_Panel.Top;
        }

        // Builds a card that looks exactly like the Book1 card in the designer.
        private Guna2ContainerControl BuildProductCard(int id)
        {
            string n = "Dyn" + id;

            Guna2ContainerControl card = new Guna2ContainerControl();
            card.Name = n + "_Container";
            card.BorderColor = Color.FromArgb(18, 77, 28);
            card.BorderRadius = 10;
            card.BorderThickness = 1;
            card.FillColor = Color.FromArgb(235, 237, 227);
            card.Margin = new Padding(10);
            card.Size = new Size(277, 322);

            Guna2PictureBox image = new Guna2PictureBox();
            image.Name = n + "_Image";
            image.BackColor = Color.Transparent;
            image.BorderRadius = 10;
            image.FillColor = Color.Transparent;
            image.Image = global::LogIn_HiveStock.Properties.Resources.dmmmsu_logo;   // until the product's own picture is set
            image.Location = new Point(9, 10);
            image.Size = new Size(258, 141);
            image.SizeMode = PictureBoxSizeMode.Zoom;
            image.TabStop = false;
            image.UseTransparentBackground = true;

            Guna2ContainerControl info = new Guna2ContainerControl();
            info.BackColor = Color.Transparent;
            info.BorderRadius = 5;
            info.FillColor = Color.FromArgb(227, 230, 217);
            info.Location = new Point(7, 156);
            info.Size = new Size(263, 159);

            Label title = new Label();
            title.Name = n + "Title_Label";
            title.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Bold);
            title.Location = new Point(3, 0);
            title.Size = new Size(260, 33);
            title.Text = "-";
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.AutoEllipsis = true;

            Label desc = new Label();
            desc.Name = n + "Info_Label";
            desc.Font = new Font("Malgun Gothic", 8.25F);
            desc.Location = new Point(9, 33);
            desc.Size = new Size(247, 51);
            desc.Text = "-";
            desc.TextAlign = ContentAlignment.TopCenter;

            Label statusCaption = new Label();
            statusCaption.AutoSize = true;
            statusCaption.Font = new Font("Microsoft Sans Serif", 9.75F);
            statusCaption.Location = new Point(13, 83);
            statusCaption.Text = "Status:";

            Label stock = new Label();
            stock.Name = "DynStock" + id + "_Status";
            stock.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            stock.Location = new Point(57, 83);
            stock.Size = new Size(98, 16);
            stock.Text = "-";

            Label priceCaption = new Label();
            priceCaption.AutoSize = true;
            priceCaption.Font = new Font("Microsoft Sans Serif", 9.75F);
            priceCaption.Location = new Point(155, 83);
            priceCaption.Text = "Price:";

            Label price = new Label();
            price.Name = "DynPricePeso" + id + "_Label";
            price.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            price.Location = new Point(192, 83);
            price.Size = new Size(64, 16);
            price.Text = "-";

            Guna2Button notify = new Guna2Button();
            notify.Name = "DynNotify" + id + "_Button";
            notify.BorderRadius = 8;
            notify.Cursor = Cursors.Hand;
            notify.FillColor = Color.FromArgb(228, 176, 40);
            notify.ForeColor = Color.Black;
            notify.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold);
            notify.Location = new Point(15, 111);
            notify.Size = new Size(115, 36);
            notify.Text = "Notify Me";
            notify.DisabledState.BorderColor = Color.DarkGray;
            notify.DisabledState.CustomBorderColor = Color.DarkGray;
            notify.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            notify.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);

            Guna2Button addToCart = new Guna2Button();
            addToCart.Name = "DynATC" + id + "_Button";
            addToCart.BorderRadius = 8;
            addToCart.Cursor = Cursors.Hand;
            addToCart.FillColor = Color.FromArgb(18, 77, 28);
            addToCart.ForeColor = Color.White;
            addToCart.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold);
            addToCart.Location = new Point(133, 111);
            addToCart.Size = new Size(115, 36);
            addToCart.Text = "Add To Cart";
            addToCart.DisabledState.BorderColor = Color.DarkGray;
            addToCart.DisabledState.CustomBorderColor = Color.DarkGray;
            addToCart.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            addToCart.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);

            info.Controls.Add(title);
            info.Controls.Add(desc);
            info.Controls.Add(statusCaption);
            info.Controls.Add(stock);
            info.Controls.Add(priceCaption);
            info.Controls.Add(price);
            info.Controls.Add(notify);
            info.Controls.Add(addToCart);

            card.Controls.Add(info);
            card.Controls.Add(image);
            return card;
        }

        private void LoadProductData()
        {
            productsCache.Clear();

            string query = "SELECT product_id, product_name, description, stock_status, price, category_id, product_img, stock_qty FROM product";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["product_id"]);

                            Image img = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("product_img")))
                            {
                                string relativePath = reader["product_img"].ToString().Trim();
                                string resolvedPath = FindImagePath(relativePath);

                                if (!string.IsNullOrEmpty(resolvedPath) && File.Exists(resolvedPath))
                                {
                                    using (FileStream fs = new FileStream(resolvedPath, FileMode.Open, FileAccess.Read))
                                    using (Image temp = Image.FromStream(fs))
                                    {
                                        img = new Bitmap(temp);
                                    }
                                }
                            }

                            productsCache[id] = new ProductData
                            {
                                Name = reader["product_name"].ToString().Trim(),
                                Description = reader["description"].ToString().Trim(),
                                StockStatus = reader["stock_status"].ToString().Trim(),
                                Price = Convert.ToDecimal(reader["price"]),
                                CategoryId = Convert.ToInt32(reader["category_id"]),
                                StockQty = Convert.ToInt32(reader["stock_qty"]),
                                ProductImage = img
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load catalog data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }



            // --- BOOKS (Category 1) ---
            BindProductCard(12, "Book1_Container", "Book1_Image", "Book1Title_Label", "Book1Info_Label", "Stock1_Status", "PricePeso1_Label", "ATC1_Button", "Notify1_Button");
            BindProductCard(7, "Book2_Container", "Book2_Image", "Book2Title_Label", "Book2Info_Label", "Stock2_Status", "PricePeso2_Label", "ATC2_Button", "Notify2_Button");
            BindProductCard(6, "Book3_Container", "Book3_Image", "Book3Title_Label", "Book3Info_Label", "Stock3_Status", "PricePeso3_Label", "ATC3_Button", "Notify3_Button");
            BindProductCard(5, "Book4_Container", "Book4_Image", "Book4Title_Label", "Book4Info_Label", "Stock4_Status", "PricePeso4_Label", "ATC4_Button", "Notify4_Button");
            BindProductCard(4, "Book5_Container", "Book5_Image", "Book5Title_Label", "Book5Info_Label", "Stock5_Status", "PricePeso5_Label", "ATC5_Button", "Notify5_Button");
            BindProductCard(3, "Book6_Container", "Book6_Image", "Book6Title_Label", "Book6Info_Label", "Stock6_Status", "PricePeso6_Label", "ATC6_Button", "Notify6_Button");
            BindProductCard(2, "Book7_Container", "Book7_Image", "Book7Title_Label", "Book7Info_Label", "Stock7_Status", "PricePeso7_Label", "ATC7_Button", "Notify7_Button");
            BindProductCard(1, "Book8_Container", "Book8_Image", "Book8Title_Label", "Book8Info_Label", "Stock8_Status", "PricePeso8_Label", "ATC8_Button", "Notify8_Button");

            // --- ID LACES (Category 2) ---
            BindProductCard(8, "ID1_Container", "ID1_Image", "ID1Title_Label", "ID1Info_Label", "IDStock1_Status", "IDPricePeso1_Label", "IDATC1_Button", "IDNotify1_Button");
            BindProductCard(9, "ID2_Container", "ID2_Image", "ID2Title_Label", "ID2Info_Label", "IDStock2_Status", "IDPricePeso2_Label", "IDATC2_Button", "IDNotify2_Button");

            // --- UNIFORMS (Category 3) ---
            BindProductCard(10, "UnivGala_Container", "UG_Image", "UGTitle_Label", "UGInfo_Label", "UGStock_Status", "UGPricePeso_Label", "UGATC_Button", "UGNotify_Button");
            BindProductCard(11, "UnifPathFit_Container", "UPF_Image", "UPFTitle_Label", "UPFInfo_Label", "UPFStock_Status", "UPFPricePeso_Label", "UPFATC_Button", "UPFNotify_Button");

            SyncCardsWithDatabase();
            ApplyCatalogFilter();
            ShowRestockAlerts();
        }

        // Tells the student about products they asked about that are back in stock.
        private void ShowRestockAlerts()
        {
            if (!UserSession.IsLoggedIn) return;

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;
                List<string> names = new List<string>();

                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT p.product_name
                  FROM notification_subscription n
                  JOIN users u ON u.user_id = n.user_id
                  JOIN product p ON p.product_id = n.product_id
                  WHERE u.id_number = @id AND n.status = 'SENT' AND n.read_at IS NULL", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", UserSession.IdNumber);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read()) names.Add(r["product_name"].ToString());
                        }
                    }

                    if (names.Count == 0) return;

                    using (MySqlCommand cmd = new MySqlCommand(
                        @"UPDATE notification_subscription n
                  JOIN users u ON u.user_id = n.user_id
                  SET n.read_at = NOW()
                  WHERE u.id_number = @id AND n.status = 'SENT' AND n.read_at IS NULL", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", UserSession.IdNumber);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Good news! These products are back in stock:\n\n- " + string.Join("\n- ", names),
                    "Restock Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                // An alert problem should never stop the catalog from opening.
            }
        }

        private string FindImagePath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return null;

            string cleanPath = relativePath.Replace('/', Path.DirectorySeparatorChar);
            string fileName = Path.GetFileName(cleanPath);
            string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);

            string baseFolder = Path.Combine(Application.StartupPath, "hivestock", "images");

            if (!Directory.Exists(baseFolder))
            {
                baseFolder = @"C:\xampp\htdocs\hivestock\images";
            }

            List<string> candidates = new List<string>
            {
                fileName,
                fileNameNoExt + ".jpg",
                fileNameNoExt + ".jpeg",
                fileNameNoExt + ".png",
                fileName + ".jpg",
                fileName + ".png"
            };

            foreach (string candidate in candidates.Distinct())
            {
                string fullPath = Path.Combine(baseFolder, candidate);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            return null;
        }

        private void BindProductCard(int productId, string containerName, string pictureBoxName,
                                     string titleName, string infoName, string stockName,
                                     string priceName, string atcName, string notifyName)
        {
            if (!productsCache.ContainsKey(productId)) return;

            ProductData p = productsCache[productId];
            p.ContainerName = containerName;

            Control[] picControls = this.Controls.Find(pictureBoxName, true);
            Control[] titleControls = this.Controls.Find(titleName, true);
            Control[] infoControls = this.Controls.Find(infoName, true);
            Control[] stockControls = this.Controls.Find(stockName, true);
            Control[] priceControls = this.Controls.Find(priceName, true);

            Control[] atcButtons = this.Controls.Find(atcName, true);
            if (atcButtons.Length > 0)
            {
                atcButtons[0].Tag = productId;
                atcButtons[0].Click -= ATC_Button_Click;
                atcButtons[0].Click += ATC_Button_Click;
            }

            Control[] notifyButtons = this.Controls.Find(notifyName, true);
            if (notifyButtons.Length > 0)
            {
                notifyButtons[0].Tag = productId;
                notifyButtons[0].Click -= Notify_Button_Click;
                notifyButtons[0].Click += Notify_Button_Click;
            }

            if (picControls.Length > 0 && picControls[0] is PictureBox pb && p.ProductImage != null)
            {
                pb.Image = p.ProductImage;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if (titleControls.Length > 0) titleControls[0].Text = p.Name;
            if (infoControls.Length > 0) infoControls[0].Text = p.Description;
            if (priceControls.Length > 0) priceControls[0].Text = $"₱{p.Price:N2}";

            if (stockControls.Length > 0)
            {
                stockControls[0].Text = p.StockStatus;

                switch (p.StockStatus.ToLower())
                {
                    case "in stock":
                        stockControls[0].ForeColor = Color.DarkGreen;
                        if (atcButtons.Length > 0) atcButtons[0].Enabled = true;
                        if (notifyButtons.Length > 0) notifyButtons[0].Enabled = false;
                        break;

                    case "low stock":
                        stockControls[0].ForeColor = Color.DarkOrange;
                        if (atcButtons.Length > 0) atcButtons[0].Enabled = true;
                        if (notifyButtons.Length > 0) notifyButtons[0].Enabled = false;
                        break;

                    case "out of stock":
                    case "no stock":
                        stockControls[0].ForeColor = Color.DarkRed;
                        if (atcButtons.Length > 0) atcButtons[0].Enabled = false;
                        if (notifyButtons.Length > 0) notifyButtons[0].Enabled = true;
                        break;

                    default:
                        stockControls[0].ForeColor = Color.Black;
                        if (atcButtons.Length > 0) atcButtons[0].Enabled = true;
                        if (notifyButtons.Length > 0) notifyButtons[0].Enabled = true;
                        break;
                }
            }
        }

        private void Filter_Dropdown_SelectedIndexChanged(object sender, EventArgs e) => ApplyCatalogFilter();

        private void Search_Input_TextChanged(object sender, EventArgs e) => ApplyCatalogFilter();

        private void Search_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ApplyCatalogFilter();
            }
        }

        private void ApplyCatalogFilter()
        {
            if (MainScrollPanel != null)
            {
                MainScrollPanel.AutoScrollPosition = new Point(0, 0);
            }

            string selectedCategory = Filter_Dropdown.SelectedItem?.ToString().Trim();
            int targetCategoryId = 0; // 0 = No Filter

            if (string.Equals(selectedCategory, "Books", StringComparison.OrdinalIgnoreCase))
                targetCategoryId = 1;
            else if (string.Equals(selectedCategory, "ID Lace", StringComparison.OrdinalIgnoreCase))
                targetCategoryId = 2;
            else if (string.Equals(selectedCategory, "Uniform", StringComparison.OrdinalIgnoreCase))
                targetCategoryId = 3;

            string rawSearchText = "";
            Control[] searchCtrls = this.Controls.Find("Search_Input", true);
            if (searchCtrls.Length > 0)
            {
                rawSearchText = searchCtrls[0].Text.Trim();
            }

            string searchQuery = rawSearchText.ToLower();
            bool isSearching = !string.IsNullOrEmpty(searchQuery);

            Control[] booksLabelCtrls = this.Controls.Find("Books_Label", true);
            if (booksLabelCtrls.Length > 0)
            {
                booksLabelCtrls[0].Text = isSearching ? $"Search results for \"{rawSearchText}\"" : "Books";
            }

            // 1. Filter individual cards strictly based on product_name (p.Name)
            foreach (var kvp in productsCache)
            {
                ProductData p = kvp.Value;
                Control[] ctrls = this.Controls.Find(p.ContainerName, true);
                if (ctrls.Length > 0)
                {
                    Control card = ctrls[0];
                    bool matchesCategory = (targetCategoryId == 0 || p.CategoryId == targetCategoryId);
                    bool matchesSearch = string.IsNullOrEmpty(searchQuery) ||
                                          p.Name.ToLower().Contains(searchQuery);

                    card.Visible = matchesCategory && matchesSearch;

                    if (isSearching && Books_Panel != null)
                    {
                        if (card.Parent != Books_Panel)
                        {
                            Books_Panel.Controls.Add(card);
                        }
                    }
                    else
                    {
                        FlowLayoutPanel targetNativePanel = Books_Panel;
                        if (p.CategoryId == 2) targetNativePanel = IDLace_Panel;
                        else if (p.CategoryId == 3) targetNativePanel = Uniform_Panel;

                        if (targetNativePanel != null && card.Parent != targetNativePanel)
                        {
                            targetNativePanel.Controls.Add(card);
                        }
                    }
                }
            }

            // 2. SEARCH MODE vs FILTER MODE
            if (isSearching)
            {
                if (IDLace_Panel != null) IDLace_Panel.Visible = false;
                if (Uniform_Panel != null) Uniform_Panel.Visible = false;

                if (Books_Panel != null)
                {
                    Books_Panel.Visible = true;
                    Books_Panel.WrapContents = true;
                    Books_Panel.Location = new Point(panelOriginalX, 10);

                    var visibleCards = Books_Panel.Controls.Cast<Control>().Where(c => c.Visible).ToList();
                    if (visibleCards.Count > 0)
                    {
                        int maxBottom = visibleCards.Max(c => c.Bottom);
                        Books_Panel.Height = maxBottom + Books_Panel.Padding.Bottom + 20;
                    }
                }
            }
            else
            {
                if (Books_Panel != null)
                {
                    Books_Panel.WrapContents = true;
                    Books_Panel.Height = booksOriginalHeight;
                }

                if (Books_Panel != null) Books_Panel.Visible = (targetCategoryId == 0 || targetCategoryId == 1);
                if (IDLace_Panel != null) IDLace_Panel.Visible = (targetCategoryId == 0 || targetCategoryId == 2);
                if (Uniform_Panel != null) Uniform_Panel.Visible = (targetCategoryId == 0 || targetCategoryId == 3);

                if (targetCategoryId == 2 && IDLace_Panel != null)
                {
                    IDLace_Panel.Location = new Point(panelOriginalX, 10);
                }
                else if (targetCategoryId == 3 && Uniform_Panel != null)
                {
                    Uniform_Panel.Location = new Point(panelOriginalX, 10);
                }
                else
                {
                    if (Books_Panel != null) Books_Panel.Location = new Point(panelOriginalX, booksOriginalY);
                    if (IDLace_Panel != null) IDLace_Panel.Location = new Point(panelOriginalX, idLaceOriginalY);
                    if (Uniform_Panel != null) Uniform_Panel.Location = new Point(panelOriginalX, uniformOriginalY);
                }
            }

            if (MainScrollPanel != null && MainScrollPanel.IsHandleCreated)
            {
                ShowScrollBar(MainScrollPanel.Handle, SB_HORZ, false);
            }

            FlowLayoutPanel[] categoryPanels = new FlowLayoutPanel[] { Books_Panel, IDLace_Panel, Uniform_Panel };
            foreach (var panel in categoryPanels)
            {
                if (panel != null && panel.IsHandleCreated)
                {
                    ShowScrollBar(panel.Handle, SB_HORZ, false);
                }
            }
        }

        // --- SUBSCRIPTION & NOTIFICATION PANEL LOGIC ---

        private int GetCurrentUserId(MySqlConnection conn)
        {
            // Lookup numeric user_id from users table using session OrderKey (id_number or username)
            string lookupQuery = "SELECT user_id FROM users WHERE id_number = @key OR username = @key LIMIT 1";
            using (MySqlCommand cmd = new MySqlCommand(lookupQuery, conn))
            {
                cmd.Parameters.AddWithValue("@key", UserSession.OrderKey);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }
            return 0;
        }

        // Kept so the designer can still find it; Notify_Button_Click does the work.
        private void Notify3_Button_Click(object sender, EventArgs e)
        {
        }

        private void Notify_Button_Click(object sender, EventArgs e)
        {
            if (!(sender is Control ctrl) || !(ctrl.Tag is int productId)) return;
            if (!productsCache.TryGetValue(productId, out ProductData p)) return;

            Notify_PopUp popup = new Notify_PopUp();
            popup.SetProduct(productId, p.Name, p.ProductImage);
            popup.ShowDialog(this);

            // The popup already saved the request. Just refresh the notification list and bell.
            RefreshNotifications();
        }

        // Swaps Notif_Button image between notification-dot (unread) and default notification (no unread)
        private void UpdateNotificationButtonIcon(bool hasUnread)
        {
            Control[] notifBtnCtrls = this.Controls.Find("Notif_Button", true);
            if (notifBtnCtrls.Length > 0)
            {
                if (notifBtnCtrls[0] is Guna2Button gunaBtn)
                {
                    gunaBtn.Image = hasUnread
                        ? Properties.Resources.notification_dot
                        : Properties.Resources.notification;
                }
                else if (notifBtnCtrls[0] is Button stdBtn)
                {
                    stdBtn.Image = hasUnread
                        ? Properties.Resources.notification_dot
                        : Properties.Resources.notification;
                }
            }
        }

        public void RefreshNotifications()
        {
            if (Notif_Panel == null) return;

            Notif_Panel.SuspendLayout();
            Notif_Panel.Controls.Clear();
            Notif_Panel.AutoScrollPosition = new Point(0, 0);

            // Card width & calculate center X coordinate
            int cardWidth = Notif_Panel.Width - 28;
            if (cardWidth < 200) cardWidth = 260;
            int xPos = Math.Max(10, (Notif_Panel.Width - cardWidth) / 2);

            int y = 10;

            // 1. MAIN HEADER: "Notifications" (18pt Bold)
            Label mainHeader = new Label();
            mainHeader.Text = "Notifications";
            mainHeader.Font = new Font("Malgun Gothic", 18F, FontStyle.Bold);
            mainHeader.ForeColor = Color.Black;
            mainHeader.BackColor = Color.Transparent;
            mainHeader.Location = new Point(xPos, y);
            mainHeader.Size = new Size(cardWidth, 36);
            Notif_Panel.Controls.Add(mainHeader);

            y += 42;

            List<RestockNotificationData> notifs = GetRestockNotifications();
            List<RestockNotificationData> unreadList = notifs.Where(n => !n.IsRead).ToList();
            List<RestockNotificationData> readList = notifs.Where(n => n.IsRead).ToList();

            // Update Bell Icon based on presence of unread notifications
            UpdateNotificationButtonIcon(unreadList.Count > 0);

            const int spacing = 10;

            // 2. SECTION 1: "Unread notifications" Header (11pt Bold)
            Label unreadHeader = new Label();
            unreadHeader.Text = "Unread notifications";
            unreadHeader.Font = new Font("Malgun Gothic", 11F, FontStyle.Bold);
            unreadHeader.ForeColor = Color.FromArgb(18, 77, 28);
            unreadHeader.BackColor = Color.Transparent;
            unreadHeader.Location = new Point(xPos, y);
            unreadHeader.Size = new Size(cardWidth, 24);
            Notif_Panel.Controls.Add(unreadHeader);

            y += 28;

            if (unreadList.Count == 0)
            {
                Label emptyUnread = new Label();
                emptyUnread.Text = "No unread notifications.";
                emptyUnread.Font = new Font("Malgun Gothic", 9.5F, FontStyle.Regular);
                emptyUnread.ForeColor = Color.Gray;
                emptyUnread.BackColor = Color.Transparent;
                emptyUnread.Location = new Point(xPos + 5, y);
                emptyUnread.Size = new Size(cardWidth, 22);
                Notif_Panel.Controls.Add(emptyUnread);
                y += 28;
            }
            else
            {
                foreach (RestockNotificationData notif in unreadList)
                {
                    Guna2Panel card = CreateNotificationCard(notif, cardWidth, xPos, y);
                    Notif_Panel.Controls.Add(card);
                    y += card.Height + spacing;
                }
            }

            y += 10; // Gap between sections

            // 3. SECTION 2: "Others" Header (11pt Bold)
            Label othersHeader = new Label();
            othersHeader.Text = "Others";
            othersHeader.Font = new Font("Malgun Gothic", 11F, FontStyle.Bold);
            othersHeader.ForeColor = Color.FromArgb(18, 77, 28);
            othersHeader.BackColor = Color.Transparent;
            othersHeader.Location = new Point(xPos, y);
            othersHeader.Size = new Size(cardWidth, 24);
            Notif_Panel.Controls.Add(othersHeader);

            y += 28;

            if (readList.Count == 0)
            {
                Label emptyOthers = new Label();
                emptyOthers.Text = "No read notifications.";
                emptyOthers.Font = new Font("Malgun Gothic", 9.5F, FontStyle.Regular);
                emptyOthers.ForeColor = Color.Gray;
                emptyOthers.BackColor = Color.Transparent;
                emptyOthers.Location = new Point(xPos + 5, y);
                emptyOthers.Size = new Size(cardWidth, 22);
                Notif_Panel.Controls.Add(emptyOthers);
                y += 28;
            }
            else
            {
                foreach (RestockNotificationData notif in readList)
                {
                    Guna2Panel card = CreateNotificationCard(notif, cardWidth, xPos, y);
                    Notif_Panel.Controls.Add(card);
                    y += card.Height + spacing;
                }
            }

            Notif_Panel.AutoScrollMinSize = new Size(0, y);
            Notif_Panel.ResumeLayout();
        }

        private List<RestockNotificationData> GetRestockNotifications()
        {
            List<RestockNotificationData> list = new List<RestockNotificationData>();
            if (!UserSession.IsLoggedIn) return list;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    int dbUserId = GetCurrentUserId(conn);
                    if (dbUserId == 0) return list;

                    // Fetch SENT notifications
                    string query = @"SELECT ns.product_id, p.product_name, ns.notified_at, ns.read_at
                                     FROM notification_subscription ns
                                     JOIN product p ON ns.product_id = p.product_id
                                     WHERE ns.user_id = @userId 
                                       AND ns.status = 'SENT'
                                     ORDER BY ns.notified_at DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", dbUserId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new RestockNotificationData
                                {
                                    ProductId = Convert.ToInt32(reader["product_id"]),
                                    ProductName = reader["product_name"].ToString(),
                                    NotifiedAt = reader.IsDBNull(reader.GetOrdinal("notified_at")) ? (DateTime?)null : reader.GetDateTime("notified_at"),
                                    IsRead = !reader.IsDBNull(reader.GetOrdinal("read_at"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error fetching notifications: " + ex.Message);
            }

            return list;
        }

        private Guna2Panel CreateNotificationCard(RestockNotificationData notif, int width, int x, int y)
        {
            Font titleFont = new Font("Malgun Gothic", 10F, FontStyle.Bold);
            Font msgFont = new Font("Malgun Gothic", 10F, FontStyle.Regular);
            Font subFont = new Font("Malgun Gothic", 8.5F, FontStyle.Italic);
            Font linkFont = new Font("Malgun Gothic", 8.5F, FontStyle.Regular); // NON-ITALIC REGULAR FONT

            string fullMessage = $"\"{notif.ProductName}\" is now available for order.";
            int innerWidth = width - 20;

            // Measure height needed for message text (2 or 3 lines)
            Size measuredSize = TextRenderer.MeasureText(fullMessage, msgFont, new Size(innerWidth, 0), TextFormatFlags.WordBreak);
            int msgHeight = measuredSize.Height;

            // Calculate card container height dynamically
            int cardHeight = 8 + 20 + 4 + msgHeight + 8 + 18 + 8; // top padding + title + gap + message + gap + footer + bottom padding

            Guna2Panel panel = new Guna2Panel();
            panel.BackColor = Color.Transparent;
            panel.BorderColor = Color.FromArgb(18, 77, 28);
            panel.BorderRadius = 8;
            panel.BorderThickness = 1;

            // Background color logic: WHITE if read, original tinted color if unread
            panel.FillColor = notif.IsRead ? Color.White : Color.FromArgb(235, 237, 227);

            panel.Location = new Point(x, y);
            panel.Size = new Size(width, cardHeight);

            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Item Back in Stock!";
            titleLabel.Font = titleFont;
            titleLabel.ForeColor = Color.FromArgb(18, 77, 28);
            titleLabel.Location = new Point(10, 8);
            titleLabel.Size = new Size(innerWidth, 20);

            // Announcement Body Message (2-3 lines)
            Label msgLabel = new Label();
            msgLabel.Text = fullMessage;
            msgLabel.Font = msgFont;
            msgLabel.ForeColor = Color.DarkSlateGray;
            msgLabel.Location = new Point(10, 32);
            msgLabel.Size = new Size(innerWidth, msgHeight);

            // Footer row Y position
            int footerY = 32 + msgHeight + 6;

            // Timestamp Label
            string timeText = notif.NotifiedAt.HasValue ? notif.NotifiedAt.Value.ToString("MMM dd, h:mm tt") : "Recently";
            Size timeSize = TextRenderer.MeasureText(timeText, subFont);

            // Toggle Mark as Read / Mark as Unread text
            string toggleLinkText = notif.IsRead ? "• Mark as Unread" : "• Mark as Read";

            LinkLabel toggleReadLink = new LinkLabel();
            toggleReadLink.Text = toggleLinkText;
            toggleReadLink.Font = linkFont; // Regular style (not italicized)
            toggleReadLink.LinkColor = Color.FromArgb(18, 77, 28);
            toggleReadLink.ActiveLinkColor = Color.DarkGreen;
            toggleReadLink.AutoSize = true;
            toggleReadLink.Cursor = Cursors.Hand;

            // Store ProductId and current state in Tag as a Tuple
            toggleReadLink.Tag = Tuple.Create(notif.ProductId, notif.IsRead);
            toggleReadLink.LinkClicked += ToggleReadStatus_LinkClicked;

            int linkWidth = TextRenderer.MeasureText(toggleLinkText, linkFont).Width;

            // RIGHT ALIGN FOOTER CONTROLS (Timestamp + Link aligned to bottom-right)
            int totalFooterWidth = timeSize.Width + 4 + linkWidth;
            int footerStartX = width - 10 - totalFooterWidth;

            Label dateLabel = new Label();
            dateLabel.Text = timeText;
            dateLabel.Font = subFont;
            dateLabel.ForeColor = Color.Gray;
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(footerStartX, footerY);

            toggleReadLink.Location = new Point(footerStartX + timeSize.Width + 4, footerY);

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(msgLabel);
            panel.Controls.Add(dateLabel);
            panel.Controls.Add(toggleReadLink);

            return panel;
        }

        private void ToggleReadStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!(sender is LinkLabel link) || !(link.Tag is Tuple<int, bool> tagData)) return;

            int productId = tagData.Item1;
            bool currentlyRead = tagData.Item2;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    int dbUserId = GetCurrentUserId(conn);

                    if (dbUserId > 0)
                    {
                        // If read, set read_at = NULL (Unread). If unread, set read_at = NOW() (Read)
                        string updateQuery = currentlyRead
                            ? @"UPDATE notification_subscription SET read_at = NULL WHERE user_id = @userId AND product_id = @productId"
                            : @"UPDATE notification_subscription SET read_at = NOW() WHERE user_id = @userId AND product_id = @productId";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@userId", dbUserId);
                            cmd.Parameters.AddWithValue("@productId", productId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Refresh panel to re-group notifications into Unread notifications / Others and update icon
                RefreshNotifications();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update notification status: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- STUBS FOR DESIGNER CLICK EVENTS ---
        private void ATC_Button_Click(object sender, EventArgs e)
        {
            if (!(sender is Control ctrl) || !(ctrl.Tag is int productId)) return;
            if (!productsCache.TryGetValue(productId, out ProductData p)) return;

            AddToCart_PopUp popup = new AddToCart_PopUp();
            popup.SetProduct(productId, p.Name, p.Price, p.ProductImage, p.StockQty);
            popup.ShowDialog();
        }

        private void Search_Input_IconRightClick(object sender, EventArgs e)
        {
            ApplyCatalogFilter();
        }

        // --- NAVIGATION EVENTS ---
        private void Cart_Button_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.ShowDialog();
        }

        private void Profile_Button_Click_1(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }

        private void Notif_Button_Click(object sender, EventArgs e)
        {
            Notif_Panel.Visible = !Notif_Panel.Visible;

            if (Notif_Panel.Visible)
            {
                Notif_Panel.BringToFront();
                RefreshNotifications();
            }
        }
    }
}