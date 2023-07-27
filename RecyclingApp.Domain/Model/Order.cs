using RecyclingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RecyclingApp.Domain.Model
{
    public class Order : BaseEntity, IAuditable
    {
        private Order() { }

        public Order(string name)
        {
            Name = name;
            Status = OrderStatus.Open;
        }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public string Name { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int TotalItems { get; private set; }
        public IEnumerable<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public enum OrderStatus
        {
            Closed = 1,
            [Display(Name = "In Transit")]
            InTransit,
            Open
        };

        public static Order Create(string name)
        {
            return new Order(name);
        }

        public void AddItem(Guid orderId, Guid productId, int quantity)
        {
            _orderItems.Add(new OrderItem(orderId, productId, quantity));
            TotalItems = _orderItems.Sum(i => i.Quantity);
        }

    }
}
