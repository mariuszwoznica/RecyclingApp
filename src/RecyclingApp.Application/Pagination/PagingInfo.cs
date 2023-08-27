namespace RecyclingApp.Application.Pagination;

public class PagingInfo
{
    public int CurrentPage { get; }
    public int PageSize { get; }
    public int TotalCount { get; }

    public PagingInfo(int pageNumber, int pageSize, int totalCount)
    {
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
}
