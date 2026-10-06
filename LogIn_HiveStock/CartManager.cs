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

    // Loads and saves product pictures and payment receipts (files in the hivestock folder;
    // the database only keeps the file name).
    public static class ProductImages
    {
        private static readonly Dictionary<int, Image> cache = new Dictionary<int, Image>();

        // Folder with the product pictures (the same place the student catalog looks).
        public static string ImagesFolder()
        {
            string folder = Path.Combine(Application.StartupPath, "hivestock", "images");
            if (!Directory.Exists(folder))
                folder = @"C:\xampp\htdocs\hivestock\images";

            Directory.CreateDirectory(folder);
            return folder;
        }

        // Folder with the payment receipts, next to the images folder.
        public static string ReceiptsFolder()
        {
            string folder = Path.Combine(Path.GetDirectoryName(ImagesFolder()), "receipts");
            Directory.CreateDirectory(folder);
            return folder;
        }

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

        // Forget the remembered picture so the next Get() reads the new file.
        public static void Forget(int productId)
        {
            cache.Remove(productId);
        }

        // Copies a chosen picture into the images folder and returns the path to store in product_img.
        public static string SaveProductImage(int productId, string sourceFile)
        {
            string ext = Path.GetExtension(sourceFile).ToLower();
            string fileName = "product_" + productId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;

            File.Copy(sourceFile, Path.Combine(ImagesFolder(), fileName), true);
            Forget(productId);

            return "images/" + fileName;
        }

        // Copies a payment receipt into the receipts folder and returns the new file name.
        public static string SaveReceipt(string sourceFile)
        {
            string ext = Path.GetExtension(sourceFile).ToLower();
            string fileName = "receipt_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" +
                              Guid.NewGuid().ToString("N").Substring(0, 6) + ext;

            File.Copy(sourceFile, Path.Combine(ReceiptsFolder(), fileName), false);
            return fileName;
        }

        // Returns a copy of the receipt picture, or null if there is none.
        public static Image LoadReceipt(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return null;

            string path = Path.Combine(ReceiptsFolder(), Path.GetFileName(fileName));
            if (!File.Exists(path)) return null;

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image temp = Image.FromStream(fs))
            {
                return new Bitmap(temp);
            }
        }

        private static string FindPath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return null;

            string cleanPath = relativePath.Replace('/', Path.DirectorySeparatorChar);
            string fileName = Path.GetFileName(cleanPath);
            string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);

            string baseFolder = ImagesFolder();

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