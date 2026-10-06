using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LogIn_HiveStock
{
    public partial class Cart : Form
    {
        private static readonly Color BrandGreen = Color.FromArgb(18, 77, 28);
        private static readonly Color BrandGold = Color.FromArgb(228, 176, 40);
        private static readonly Color RowFill = Color.FromArgb(235, 237, 227);
        private static readonly Color CheckGray = Color.FromArgb(125, 137, 149);

        private const int RowHeight = 63;
        private const int RowSpacing = 6;

        // One entry per product currently shown in the cart window.
        private class CartRow
        {
            public CartItem Item;
            public Guna2Panel Panel;
            public Guna2PictureBox Picture;
            public Guna2CheckBox Check;
            public Label PriceLabel;
        }

        private readonly List<CartRow> rows = new List<CartRow>();
        private readonly Image deleteIcon;
        private Guna2Button removeSelectedButton;
        private Label emptyLabel;
        private bool syncingChecks;

        public Cart()
        {
            InitializeComponent();

            deleteIcon = Product1Delete_Button.Image;
            Products_Panel.Controls.Clear();

            BuildExtraControls();

            SelectAll_Check.CheckedChanged += SelectAll_Check_CheckedChanged;
            this.Load += Cart_Load;

        }

        // Controls that are not in the designer: "Remove Selected" and the empty-cart message.
        private void BuildExtraControls()
        {
            removeSelectedButton = new Guna2Button();
            removeSelectedButton.Text = "Remove Selected";
            removeSelectedButton.BackColor = Color.Transparent;
            removeSelectedButton.BorderRadius = 8;
            removeSelectedButton.FillColor = Color.FromArgb(178, 34, 34);
            removeSelectedButton.ForeColor = Color.White;
            removeSelectedButton.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold);
            removeSelectedButton.Cursor = Cursors.Hand;
            removeSelectedButton.Size = new Size(170, 36);
            removeSelectedButton.Location = new Point(100, 21);
            removeSelectedButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            removeSelectedButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            removeSelectedButton.Enabled = false;
            removeSelectedButton.Click += RemoveSelected_Click;
            Total_Panel.Controls.Add(removeSelectedButton);

            emptyLabel = new Label();
            emptyLabel.Text = "Your cart is empty.";
            emptyLabel.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold);
            emptyLabel.ForeColor = Color.Gray;
            emptyLabel.BackColor = Color.Transparent;
            emptyLabel.TextAlign = ContentAlignment.MiddleCenter;
            emptyLabel.Size = new Size(Products_Panel.Width, 60);
            emptyLabel.Location = new Point(0, 60);
            emptyLabel.Visible = false;
            Products_Panel.Controls.Add(emptyLabel);
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            LoadCartData();
        }

        // Rebuilds every row from CartManager.Items, however many there are.
        private void LoadCartData()
        {
            Products_Panel.SuspendLayout();

            foreach (CartRow row in rows)
            {
                Products_Panel.Controls.Remove(row.Panel);
                row.Picture.Image = null; // the image belongs to the cart item, not to this row
                row.Panel.Dispose();
            }
            rows.Clear();
            Products_Panel.AutoScrollPosition = new Point(0, 0);

            int y = 3;
            foreach (CartItem item in CartManager.Items.ToList())
            {
                CartRow row = CreateRow(item, y);
                rows.Add(row);
                Products_Panel.Controls.Add(row.Panel);
                y += RowHeight + RowSpacing;
            }

            emptyLabel.Visible = rows.Count == 0;
            Products_Panel.ResumeLayout();

            syncingChecks = true;
            SelectAll_Check.Checked = false;
            syncingChecks = false;

            SelectAll_Check.Enabled = rows.Count > 0;
            BuyNow_Button.Enabled = rows.Count > 0;

            UpdateTotal();
            UpdateSelectionState();
        }
        private CartRow CreateRow(CartItem item, int y)
        {
            CartRow row = new CartRow();
            row.Item = item;

            Guna2Panel panel = new Guna2Panel();
            panel.BackColor = Color.Transparent;
            panel.BorderRadius = 10;
            panel.FillColor = RowFill;
            panel.Location = new Point(27, y);
            panel.Size = new Size(771, RowHeight);

            Guna2CheckBox check = new Guna2CheckBox();
            check.AutoSize = true;
            check.Location = new Point(16, 26);
            check.Size = new Size(15, 14);
            check.CheckedState.BorderColor = BrandGold;
            check.CheckedState.BorderRadius = 3;
            check.CheckedState.BorderThickness = 0;
            check.CheckedState.FillColor = BrandGold;
            check.UncheckedState.BorderColor = CheckGray;
            check.UncheckedState.BorderRadius = 3;
            check.UncheckedState.BorderThickness = 0;
            check.UncheckedState.FillColor = CheckGray;

            Guna2PictureBox picture = new Guna2PictureBox();
            picture.BackColor = Color.Transparent;
            picture.BorderRadius = 10;
            picture.FillColor = Color.Transparent;
            picture.Image = item.Image;
            picture.Location = new Point(35, 7);
            picture.Size = new Size(80, 50);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.TabStop = false;
            picture.UseTransparentBackground = true;

            Label nameLabel = new Label();
            nameLabel.Font = new Font("Malgun Gothic", 9.75F, FontStyle.Bold);
            nameLabel.Location = new Point(118, 9);
            nameLabel.Size = new Size(471, 24);
            nameLabel.Text = item.Name;
            nameLabel.TextAlign = ContentAlignment.MiddleLeft;
            nameLabel.AutoEllipsis = true;

            Label priceLabel = new Label();
            priceLabel.Font = new Font("Malgun Gothic", 9.75F, FontStyle.Bold);
            priceLabel.ForeColor = BrandGreen;
            priceLabel.Location = new Point(118, 34);
            priceLabel.Size = new Size(471, 19);
            priceLabel.Text = FormatPriceText(item);
            priceLabel.TextAlign = ContentAlignment.MiddleLeft;

            Label quantityLabel = new Label();
            quantityLabel.Font = new Font("Malgun Gothic", 9F);
            quantityLabel.Location = new Point(595, 19);
            quantityLabel.Size = new Size(60, 29);
            quantityLabel.Text = "Quantity:";
            quantityLabel.TextAlign = ContentAlignment.MiddleLeft;

            Guna2NumericUpDown upDown = new Guna2NumericUpDown();
            upDown.BackColor = Color.Transparent;
            upDown.BorderColor = RowFill;
            upDown.BorderRadius = 5;
            upDown.Font = new Font("Segoe UI", 9F);
            upDown.Location = new Point(649, 17);
            upDown.Size = new Size(71, 32);
            upDown.UpDownButtonFillColor = BrandGold;
            upDown.UpDownButtonForeColor = BrandGreen;
            upDown.Minimum = 1;
            upDown.Maximum = Math.Max(1, Math.Max(item.MaxQuantity, item.Quantity)); // cannot order more than stock
            upDown.Value = Math.Max(1, item.Quantity);

            Guna2CircleButton deleteButton = new Guna2CircleButton();
            deleteButton.BackColor = Color.Transparent;
            deleteButton.FillColor = Color.White;
            deleteButton.HoverState.FillColor = Color.FromArgb(224, 224, 224);
            deleteButton.PressedColor = RowFill;
            deleteButton.PressedDepth = 100;
            deleteButton.Image = deleteIcon;
            deleteButton.ImageSize = new Size(25, 25);
            deleteButton.Location = new Point(733, 19);
            deleteButton.Size = new Size(28, 30);

            // Changing the quantity updates the cart item, this row's subtotal and the grand total.
            upDown.ValueChanged += (s, e) =>
            {
                item.Quantity = (int)upDown.Value;
                CartManager.SaveQuantity(item);
                priceLabel.Text = FormatPriceText(item);
                UpdateTotal();
            };

            check.CheckedChanged += (s, e) => OnRowCheckChanged();

            deleteButton.Click += (s, e) => BeginInvoke(new Action(() =>
            {
                CartManager.RemoveItem(item);
                LoadCartData();
            }));

            panel.Controls.Add(deleteButton);
            panel.Controls.Add(upDown);
            panel.Controls.Add(quantityLabel);
            panel.Controls.Add(check);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(picture);

            row.Panel = panel;
            row.Picture = picture;
            row.Check = check;
            row.PriceLabel = priceLabel;
            return row;
        }

        private static string FormatPriceText(CartItem item)
        {
            return $"₱{item.Price:N2} each   •   Subtotal: ₱{item.Price * item.Quantity:N2}";
        }
        private void UpdateTotal()
        {
            decimal total = CartManager.GetTotal();

            PesoTotal_Label.AutoSize = true;
            PesoTotal_Label.Text = $"₱{total:N2}";
            // Keep the amount right-aligned next to Buy Now, whatever its width.
            PesoTotal_Label.Left = BuyNow_Button.Left - 4 - PesoTotal_Label.Width;
            Total_Label.Left = PesoTotal_Label.Left - Total_Label.Width - 6;

            ProductTotal_Label.Text = CartManager.Items.Count.ToString();
        }

        private void SelectAll_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (syncingChecks) return;

            syncingChecks = true;
            foreach (CartRow row in rows)
                row.Check.Checked = SelectAll_Check.Checked;
            syncingChecks = false;

            UpdateSelectionState();
        }

        private void OnRowCheckChanged()
        {
            if (syncingChecks) return;

            syncingChecks = true;
            SelectAll_Check.Checked = rows.Count > 0 && rows.All(r => r.Check.Checked);
            syncingChecks = false;

            UpdateSelectionState();
        }

        private void UpdateSelectionState()
        {
            int selected = rows.Count(r => r.Check.Checked);
            removeSelectedButton.Enabled = selected > 0;
            removeSelectedButton.Text = selected > 0 ? $"Remove Selected ({selected})" : "Remove Selected";
        }

        private void RemoveSelected_Click(object sender, EventArgs e)
        {
            List<CartItem> selected = rows.Where(r => r.Check.Checked).Select(r => r.Item).ToList();
            if (selected.Count == 0) return;

            string message = selected.Count == 1
                ? "Remove the selected item from your cart?"
                : $"Remove {selected.Count} selected items from your cart?";

            if (MessageBox.Show(message, "HiveStock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            foreach (CartItem item in selected)
                CartManager.RemoveItem(item);

            LoadCartData();
        }

        private void L_Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuyNow_Button_Click(object sender, EventArgs e)
        {
            if (CartManager.Items.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "HiveStock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (Upload_QR uploadQR = new Upload_QR())
            {
                uploadQR.ShowDialog(this);
            }

            // After a successful payment the cart has been emptied; refresh what is shown.
            LoadCartData();
        }
    }
}
