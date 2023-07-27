namespace RecyclingApp.Application.RequestParamiters
{
    public class GetProductsRequest : PaginationRequest
    {
        public string[] Type { get; set; }
        public string Name { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string OrderBy { get; set; }
    }
}
