using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace LogIn_HiveStock
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Image Image { get; set; }
    }

    public static class CartManager
    {
        public static List<CartItem> Items { get; } = new List<CartItem>();

        public static void AddItem(int productId, string name, decimal price, Image image, int quantity)
        {
            CartItem existing = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existing != null)
                existing.Quantity += quantity;
            else
                Items.Add(new CartItem { ProductId = productId, Name = name, Price = price, Image = image, Quantity = quantity });
        }

        public static void RemoveItem(int productId) => Items.RemoveAll(i => i.ProductId == productId);

        public static decimal GetTotal() => Items.Sum(i => i.Price * i.Quantity);
    }
}