using System;

namespace RecyclingApp.Application.Models
{
    public class ProductDto
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
    }
}
