using System;

namespace RecyclingApp.Domain.Model
{
    public class OrderItem
    {
        private OrderItem() { }

        public OrderItem(Guid orderId, Guid productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

    }
}
