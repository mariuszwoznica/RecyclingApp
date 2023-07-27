namespace RecyclingApp.Application.RequestParamiters
{
    public class GetUsersRequest : PaginationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrderBy { get; set; }
    }
}
