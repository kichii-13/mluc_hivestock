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

            ApplyCatalogFilter();
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

        // --- STUBS FOR DESIGNER CLICK EVENTS ---
        private void ATC_Button_Click(object sender, EventArgs e)
        {
            if (!(sender is Control ctrl) || !(ctrl.Tag is int productId)) return;
            if (!productsCache.TryGetValue(productId, out ProductData p)) return;

            AddToCart_PopUp popup = new AddToCart_PopUp();
            popup.SetProduct(productId, p.Name, p.Price, p.ProductImage, p.StockQty);
            popup.ShowDialog();
        }

        private void Notify3_Button_Click(object sender, EventArgs e)
        {
            Notify_PopUp notify = new Notify_PopUp();
            notify.ShowDialog();
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
    }
}