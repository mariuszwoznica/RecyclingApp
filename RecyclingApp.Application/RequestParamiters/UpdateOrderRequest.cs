using System;

namespace RecyclingApp.Application.RequestParamiters
{
    public class UpdateOrderRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
