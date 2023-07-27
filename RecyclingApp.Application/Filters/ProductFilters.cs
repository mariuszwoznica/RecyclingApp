namespace RecyclingApp.Application.Filters
{
    public class ProductFilters
    {
        public string[] Type { get; private set; }
        public string Name { get; private set; }
        public int MinPrice { get; private set; }
        public int MaxPrice { get; private set; }
        public string OrderBy { get; private set; }

        public ProductFilters(string[] type, string name, int minPrice, int maxPrice, string orderBy)
        {
            Type = type;
            Name = name;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            OrderBy = orderBy;
        }
    }
}
