using System;

namespace RecyclingApp.Application.RequestParamiters
{
    public class GetOrdersRequest : PaginationRequest
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime MinCreatedAt { get; set; }
        public DateTime MaxCreatedAt { get; set; }
        public int MinProductCount { get; set; }
        public int MaxProductCount { get; set; }
        public string OrderBy { get; set; }
    }
}
