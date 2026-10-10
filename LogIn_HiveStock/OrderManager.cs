using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;

namespace LogIn_HiveStock
{
    /// One product line inside a placed order
    public class OrderLine
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Image Image { get; set; }
        public bool IsReceived { get; set; }
        public DateTime? ReceivedAt { get; set; }

        public decimal Subtotal
        {
            get { return Price * Quantity; }
        }
    }

    /// A placed order. Payment is checked per order; handing over is tracked per product.
    public class OrderRecord
    {
        public int OrderId { get; set; }
        public string UserKey { get; set; }
        public DateTime PlacedAt { get; set; }
        public string ReceiptFileName { get; set; }
        public string PaymentStatus { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
        public List<OrderLine> Lines { get; } = new List<OrderLine>();

        public string OrderNumber
        {
            get { return "HS-" + OrderId.ToString("D4"); }
        }

        public decimal Total
        {
            get { return Lines.Sum(l => l.Subtotal); }
        }
    }

    public static class OrderManager
    {
        public const string PaymentVerifying = "Verifying Payment";
        public const string PaymentPaid = "Paid";
        public const string PaymentRejected = "Rejected";

        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        /// Status text for a whole order, from its payment status and how many products were handed over.
        public static string TransactionStatus(string paymentStatus, int itemCount, int receivedCount)
        {
            if (paymentStatus == PaymentRejected) return "Payment Rejected";
            if (paymentStatus != PaymentPaid) return "Verifying Payment";
            if (itemCount > 0 && receivedCount >= itemCount) return "Completed";
            if (receivedCount == 0) return "Paid - Ready for Pickup";
            return "Partially Received (" + receivedCount + " of " + itemCount + ")";
        }

        // Saves an order (status: Verifying Payment) and takes the quantities off the stock.
        // The stock status (In / Low / Out of Stock) is worked out by the database from the quantity.
        // Returns null (after showing a message) if anything failed, so the cart must stay as it is.
        public static OrderRecord PlaceOrder(string userKey, IEnumerable<CartItem> items, string receiptFileName)
        {
            OrderRecord order = new OrderRecord
            {
                UserKey = userKey ?? "",
                PlacedAt = DateTime.Now,
                ReceiptFileName = receiptFileName,
                PaymentStatus = PaymentVerifying,
                IsCompleted = false
            };

            foreach (CartItem item in items)
            {
                order.Lines.Add(new OrderLine
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Image = item.Image
                });
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlTransaction tx = conn.BeginTransaction())
                    {
                        using (MySqlCommand cmd = new MySqlCommand(
                            @"INSERT INTO customer_orders (user_key, placed_at, receipt_file, is_completed, payment_status)
                              VALUES (@u, @t, @r, 0, @ps)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@u", order.UserKey);
                            cmd.Parameters.AddWithValue("@t", order.PlacedAt);
                            cmd.Parameters.AddWithValue("@r", receiptFileName ?? "");
                            cmd.Parameters.AddWithValue("@ps", PaymentVerifying);
                            cmd.ExecuteNonQuery();
                            order.OrderId = (int)cmd.LastInsertedId;
                        }

                        foreach (OrderLine line in order.Lines)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(
                                @"INSERT INTO customer_order_items (order_id, product_id, product_name, unit_price, quantity)
                                  VALUES (@o, @p, @n, @pr, @q)", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@o", order.OrderId);
                                cmd.Parameters.AddWithValue("@p", line.ProductId);
                                cmd.Parameters.AddWithValue("@n", line.Name);
                                cmd.Parameters.AddWithValue("@pr", line.Price);
                                cmd.Parameters.AddWithValue("@q", line.Quantity);
                                cmd.ExecuteNonQuery();
                            }

                            // Take the quantity off the stock, but only if enough is left.
                            using (MySqlCommand cmd = new MySqlCommand(
                                @"UPDATE product SET stock_qty = stock_qty - @q
                                  WHERE product_id = @p AND stock_qty >= @q", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@p", line.ProductId);
                                cmd.Parameters.AddWithValue("@q", line.Quantity);

                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    tx.Rollback();
                                    MessageBox.Show(
                                        "Sorry, there is not enough stock of \"" + line.Name + "\" for this order.\n\n" +
                                        "Nothing was charged or saved. Please lower the quantity in your cart.",
                                        "Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return null;
                                }
                            }
                        }

                        tx.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your order could not be saved: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return order;
        }

        /// The user's orders, newest first. Each record holds only the products that are
        /// still pending (completed = false) or already received (completed = true).
        public static List<OrderRecord> GetOrders(string userKey, bool completed)
        {
            List<OrderRecord> result = new List<OrderRecord>();
            Dictionary<int, OrderRecord> byId = new Dictionary<int, OrderRecord>();

            const string sql =
                @"SELECT o.order_id, o.placed_at, o.receipt_file, o.payment_status,
                         i.order_item_id, i.product_id, i.product_name, i.unit_price,
                         i.quantity, i.received_at, p.product_img
                  FROM customer_orders o
                  JOIN customer_order_items i ON i.order_id = o.order_id
                  LEFT JOIN product p ON p.product_id = i.product_id
                  WHERE o.user_key = @u AND i.is_received = @c
                  ORDER BY o.placed_at DESC, o.order_id DESC, i.order_item_id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", userKey ?? "");
                        cmd.Parameters.AddWithValue("@c", completed ? 1 : 0);

                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                int orderId = Convert.ToInt32(r["order_id"]);

                                OrderRecord order;
                                if (!byId.TryGetValue(orderId, out order))
                                {
                                    order = new OrderRecord
                                    {
                                        OrderId = orderId,
                                        UserKey = userKey ?? "",
                                        PlacedAt = Convert.ToDateTime(r["placed_at"]),
                                        ReceiptFileName = r["receipt_file"] == DBNull.Value
                                            ? "" : r["receipt_file"].ToString(),
                                        PaymentStatus = r["payment_status"].ToString(),
                                        IsCompleted = completed
                                    };
                                    byId[orderId] = order;
                                    result.Add(order);
                                }

                                int productId = Convert.ToInt32(r["product_id"]);
                                string imgPath = r["product_img"] == DBNull.Value
                                    ? null : r["product_img"].ToString().Trim();

                                order.Lines.Add(new OrderLine
                                {
                                    OrderItemId = Convert.ToInt32(r["order_item_id"]),
                                    ProductId = productId,
                                    Name = r["product_name"].ToString(),
                                    Price = Convert.ToDecimal(r["unit_price"]),
                                    Quantity = Convert.ToInt32(r["quantity"]),
                                    Image = ProductImages.Get(productId, imgPath),
                                    IsReceived = completed,
                                    ReceivedAt = r["received_at"] == DBNull.Value
                                        ? (DateTime?)null : Convert.ToDateTime(r["received_at"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load your orders: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        /// ADMIN: the receipt is valid, so the order becomes Paid.
        public static bool VerifyPayment(int orderId, string checkedBy)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"UPDATE customer_orders
                          SET payment_status = @paid, payment_checked_by = @by, payment_checked_at = @t
                          WHERE order_id = @id AND payment_status = @verifying", conn))
                    {
                        cmd.Parameters.AddWithValue("@paid", PaymentPaid);
                        cmd.Parameters.AddWithValue("@verifying", PaymentVerifying);
                        cmd.Parameters.AddWithValue("@by", checkedBy ?? "");
                        cmd.Parameters.AddWithValue("@t", DateTime.Now);
                        cmd.Parameters.AddWithValue("@id", orderId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not verify the payment: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// ADMIN: the receipt is not valid. The order is rejected and its quantities go back into stock.
        public static bool RejectPayment(int orderId, string checkedBy)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlTransaction tx = conn.BeginTransaction())
                    {
                        int changed;
                        using (MySqlCommand cmd = new MySqlCommand(
                            @"UPDATE customer_orders
                              SET payment_status = @rejected, payment_checked_by = @by, payment_checked_at = @t
                              WHERE order_id = @id AND payment_status = @verifying", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rejected", PaymentRejected);
                            cmd.Parameters.AddWithValue("@verifying", PaymentVerifying);
                            cmd.Parameters.AddWithValue("@by", checkedBy ?? "");
                            cmd.Parameters.AddWithValue("@t", DateTime.Now);
                            cmd.Parameters.AddWithValue("@id", orderId);
                            changed = cmd.ExecuteNonQuery();
                        }

                        if (changed == 0)
                        {
                            tx.Rollback();
                            return false;
                        }

                        // Nothing was paid for, so the ordered quantities return to stock.
                        using (MySqlCommand cmd = new MySqlCommand(
                            @"UPDATE product p
                              JOIN customer_order_items i ON i.product_id = p.product_id
                              SET p.stock_qty = p.stock_qty + i.quantity
                              WHERE i.order_id = @id", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", orderId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not reject the payment: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// STAFF or ADMIN: hands products over to the student (only for orders that are Paid).
        /// Returns how many products were marked as received.
        public static int ReleaseItems(IEnumerable<int> orderItemIds, string releasedBy)
        {
            List<int> ids = orderItemIds.Distinct().ToList();
            if (ids.Count == 0) return 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlTransaction tx = conn.BeginTransaction())
                    {
                        DateTime now = DateTime.Now;
                        int changed = 0;

                        foreach (int id in ids)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(
                                @"UPDATE customer_order_items i
                                  JOIN customer_orders o ON o.order_id = i.order_id
                                  SET i.is_received = 1, i.received_at = @t, i.released_by = @by
                                  WHERE i.order_item_id = @id AND i.is_received = 0 AND o.payment_status = @paid",
                                conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@t", now);
                                cmd.Parameters.AddWithValue("@by", releasedBy ?? "");
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@paid", PaymentPaid);
                                changed += cmd.ExecuteNonQuery();
                            }
                        }

                        // Close out any order whose products have all been handed over.
                        using (MySqlCommand cmd = new MySqlCommand(
                            @"UPDATE customer_orders o
                              SET o.is_completed = 1, o.completed_at = @t
                              WHERE o.is_completed = 0 AND o.payment_status = @paid
                                AND NOT EXISTS (SELECT 1 FROM customer_order_items i
                                                WHERE i.order_id = o.order_id AND i.is_received = 0)",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@t", now);
                            cmd.Parameters.AddWithValue("@paid", PaymentPaid);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return changed;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update the order: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}