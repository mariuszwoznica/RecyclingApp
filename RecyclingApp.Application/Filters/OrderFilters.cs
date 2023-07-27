using System;
using static RecyclingApp.Domain.Model.Order;

namespace RecyclingApp.Application.Filters
{
    public class OrderFilters
    {
        public string Name { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime MinCreatedAt { get; set; }
        public DateTime MaxCreatedAt { get; set; }
        public int MinProductCount { get; set; }
        public int MaxProductCount { get; set; }
        public string OrderBy { get; set; }

        public OrderFilters(string name, string status, DateTime minCreatedAt, DateTime maxCreatedAt,
            int minProductCount, int maxProductCount, string orderBy)
        {
            Name = name;
            Status = Enum.TryParse(status, true, out OrderStatus result) ? result : default;
            MinCreatedAt = minCreatedAt;
            MaxCreatedAt = maxCreatedAt;
            MinProductCount = minProductCount;
            MaxProductCount = maxProductCount;
            OrderBy = orderBy;
        }
    }
}
