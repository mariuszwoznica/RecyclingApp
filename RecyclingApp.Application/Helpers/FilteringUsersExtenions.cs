using RecyclingApp.Application.Filters;
using RecyclingApp.Domain.Model;
using System.Linq;

namespace RecyclingApp.Application.Helpers
{
    public static class FilteringUsersExtenions
    {
        public static IQueryable<User> SearchUsers(this IQueryable<User> query, UserFilters filters)
        {
            query = filters.FirstName != null ? query.Where(q => q.FirstName.ToUpper() == filters.FirstName.ToUpper()) : query;
            query = filters.LastName != null ? query.Where(q => q.LastName.ToUpper() == filters.LastName.ToUpper()) : query;

            return query;
        }
    }
}
