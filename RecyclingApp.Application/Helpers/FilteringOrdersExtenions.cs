using RecyclingApp.Application.Filters;
using RecyclingApp.Domain.Model;
using System.Linq;

namespace RecyclingApp.Application.Helpers
{
    public static class FilteringOrdersExtenions
    {
        public static IQueryable<Order> SearchOrders(this IQueryable<Order> query, OrderFilters filters)
        {
            if (filters.Status != default)
                query = query.Where(q => q.Status == filters.Status);
            if (filters.Name != null)
                query = query.Where(q => q.Name.ToUpper() == filters.Name.ToUpper());

            return query;
        }

        public static IQueryable<Order> FilterOrders(this IQueryable<Order> query, OrderFilters filters)
        {
            query = filters.MinCreatedAt != default && filters.MaxCreatedAt != default ?
                query.Where(q => q.CreatedAt >= filters.MinCreatedAt && q.CreatedAt <= filters.MaxCreatedAt) :
                filters.MinCreatedAt != default ? query.Where(q => q.CreatedAt >= filters.MinCreatedAt) :
                filters.MaxCreatedAt != default ? query.Where(q => q.CreatedAt <= filters.MaxCreatedAt) : query;

            query = filters.MinProductCount != default && filters.MaxProductCount != default ?
                query.Where(q => q.TotalItems >= filters.MinProductCount && q.TotalItems <= filters.MaxProductCount) :
                filters.MinProductCount != default ? query.Where(q => q.TotalItems >= filters.MinProductCount) :
                filters.MaxProductCount != default ? query.Where(q => q.TotalItems <= filters.MaxProductCount) : query;

            return query;
        }


    }
}
