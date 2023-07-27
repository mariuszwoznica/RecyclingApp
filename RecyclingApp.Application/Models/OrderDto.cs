using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.Models
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
        public int TotalItems { get; set; }

    }
}
