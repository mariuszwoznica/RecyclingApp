namespace RecyclingApp.Application.Filters
{
    public class UserFilters
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string OrderBy { get; private set; }

        public UserFilters(string firstName, string lastName, string orderBy)
        {
            FirstName = firstName;
            LastName = lastName;
            OrderBy = orderBy;
        }
    }


}
