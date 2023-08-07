namespace RecyclingApp.Application.Wrappers
{
    public class PageResponse<T> : Response<T>
    {
        public int Total { get; private set; }
        public PageResponse(T response, int totalCount)
        {
            Total = totalCount;
            Data = response;
        }
    }
}
