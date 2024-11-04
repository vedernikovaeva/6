using System;
namespace ШП_ЛБ6
{
	public class Order
	{
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; }

        public Order(int orderId, int customerId, double orderTotal, string orderStatus = "В очікуванні")
        {
            OrderId = orderId;
            CustomerId = customerId;
            OrderTotal = orderTotal;
            OrderStatus = orderStatus;
        }

        public string GetOrderStatus()
        {
            return $"{OrderStatus}";
        }

        public void ConfirmOrder(string notificationMethod)
        {
            OrderStatus = "Замовлення підтверджено!";
            SendNotification(notificationMethod);
        }

        private void SendNotification(string notificationMethod)
        {
            Console.WriteLine($"Повідомлення надіслано на {notificationMethod}");
        }
    }
}

