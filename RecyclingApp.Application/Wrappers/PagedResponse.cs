namespace RecyclingApp.Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int Total { get; private set; }
        public PagedResponse(T response, int totalCount)
        {
            Total = totalCount;
            Data = response;
        }
    }
}
