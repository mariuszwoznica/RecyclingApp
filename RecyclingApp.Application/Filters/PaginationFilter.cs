namespace RecyclingApp.Application.Filters
{
    public class PaginationFilter
    {
        public int Page { get; set; }
        public int Limit { get; set; }

        public PaginationFilter()
        {
            Page = 1;
            Limit = 100;
        }

        public PaginationFilter(int page, int limit)
        {
            Page = page <= 0 ? 1 : page;
            Limit = limit > 100 || limit <= 0 ? 100 : limit;
        }
    }
}
