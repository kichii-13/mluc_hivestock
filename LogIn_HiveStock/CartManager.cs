using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;

namespace LogIn_HiveStock
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Image Image { get; set; }
        public int MaxQuantity { get; set; } = int.MaxValue;
    }

    // Loads product pictures from the images folder (same lookup the catalog uses)
    // and keeps them so the cart and orders can share them.
    public static class ProductImages
    {
        private static readonly Dictionary<int, Image> cache = new Dictionary<int, Image>();

        public static Image Get(int productId, string relativePath)
        {
            Image img;
            if (cache.TryGetValue(productId, out img)) return img;

            string path = FindPath(relativePath);
            if (path == null) return null;

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image temp = Image.FromStream(fs))
            {
                img = new Bitmap(temp);
            }

            cache[productId] = img;
            return img;
        }

        private static string FindPath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return null;

            string cleanPath = relativePath.Replace('/', Path.DirectorySeparatorChar);
            string fileName = Path.GetFileName(cleanPath);
            string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);

            string baseFolder = Path.Combine(Application.StartupPath, "hivestock", "images");
            if (!Directory.Exists(baseFolder))
                baseFolder = @"C:\xampp\htdocs\hivestock\images";

            string[] candidates =
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
                if (File.Exists(fullPath)) return fullPath;
            }
            return null;
        }
    }

    public static class CartManager
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        private static readonly List<CartItem> cache = new List<CartItem>();
        private static string loadedFor = null;

        // The logged-in user's cart. Read-only on purpose: change it through the methods below
        // so every change is saved to the database.
        public static IReadOnlyList<CartItem> Items
        {
            get
            {
                EnsureLoaded();
                return cache;
            }
        }

        // Reloads the cart from the database whenever a different user is logged in.
        private static void EnsureLoaded()
        {
            string key = UserSession.OrderKey ?? "";
            if (key == loadedFor) return;

            loadedFor = key;
            cache.Clear();
            if (key.Length == 0) return; // guests have no saved cart

            try
            {
                const string sql =
                    @"SELECT c.product_id, c.quantity, p.product_name, p.price, p.product_img, p.stock_qty
                      FROM cart_items c
                      JOIN product p ON p.product_id = c.product_id
                      WHERE c.user_key = @u
                      ORDER BY c.cart_item_id";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", key);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                int productId = Convert.ToInt32(r["product_id"]);
                                int stock = Convert.ToInt32(r["stock_qty"]);
                                if (stock < 1) continue; // sold out since it was added

                                int qty = Math.Max(1, Math.Min(Convert.ToInt32(r["quantity"]), stock));
                                string imgPath = r["product_img"] == DBNull.Value
                                    ? null : r["product_img"].ToString().Trim();

                                cache.Add(new CartItem
                                {
                                    ProductId = productId,
                                    Name = r["product_name"].ToString().Trim(),
                                    Price = Convert.ToDecimal(r["price"]),
                                    Quantity = qty,
                                    MaxQuantity = stock,
                                    Image = ProductImages.Get(productId, imgPath)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load your cart: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void AddItem(int productId, string name, decimal price, Image image, int quantity, int maxQuantity)
        {
            EnsureLoaded();
            if (maxQuantity < 1) maxQuantity = 1;

            CartItem existing = cache.FirstOrDefault(i => i.ProductId == productId);
            if (existing != null)
            {
                existing.MaxQuantity = maxQuantity;
                existing.Quantity = Math.Min(existing.Quantity + quantity, maxQuantity);
            }
            else
            {
                existing = new CartItem
                {
                    ProductId = productId,
                    Name = name,
                    Price = price,
                    Image = image,
                    Quantity = Math.Min(quantity, maxQuantity),
                    MaxQuantity = maxQuantity
                };
                cache.Add(existing);
            }

            SaveQuantity(existing);
        }

        public static int GetQuantity(int productId)
        {
            CartItem existing = Items.FirstOrDefault(i => i.ProductId == productId);
            return existing == null ? 0 : existing.Quantity;
        }

        // Saves the item's current quantity (call after changing item.Quantity).
        public static void SaveQuantity(CartItem item)
        {
            Execute(@"INSERT INTO cart_items (user_key, product_id, quantity)
                      VALUES (@u, @p, @q)
                      ON DUPLICATE KEY UPDATE quantity = @q",
                    item.ProductId, item.Quantity);
        }

        public static void RemoveItem(CartItem item)
        {
            cache.Remove(item);
            Execute("DELETE FROM cart_items WHERE user_key = @u AND product_id = @p", item.ProductId);
        }

        public static void RemoveItem(int productId)
        {
            CartItem item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null) RemoveItem(item);
        }

        // Empties the current user's cart (used after payment).
        public static void Clear()
        {
            cache.Clear();
            Execute("DELETE FROM cart_items WHERE user_key = @u");
        }

        public static decimal GetTotal() => Items.Sum(i => i.Price * i.Quantity);

        private static void Execute(string sql, int productId = 0, int quantity = 0)
        {
            string key = UserSession.OrderKey ?? "";
            if (key.Length == 0) return; // guests are not saved

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", key);
                        cmd.Parameters.AddWithValue("@p", productId);
                        cmd.Parameters.AddWithValue("@q", quantity);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save your cart: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}