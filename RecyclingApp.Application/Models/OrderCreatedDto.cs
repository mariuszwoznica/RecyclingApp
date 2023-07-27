using System;

namespace RecyclingApp.Application.Models
{
    public class OrderCreatedDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
