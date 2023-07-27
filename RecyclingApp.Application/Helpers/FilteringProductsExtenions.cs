using RecyclingApp.Application.Filters;
using RecyclingApp.Domain.Model;
using System.Linq;

namespace RecyclingApp.Application.Helpers
{
    public static class FilteringProductsExtenions
    {
        public static IQueryable<Product> SearchProducts(this IQueryable<Product> query, ProductFilters filters)
        {
            query = filters.Type != null && filters.Type.Length == 1 ? query.Where(q => q.Type.ToUpper() == filters.Type[0].ToUpper()) : query;
            query = filters.Name != null ? query.Where(q => q.Name.ToUpper() == filters.Name.ToUpper()) : query;

            return query;
        }

        public static IQueryable<Product> FilterProducts(this IQueryable<Product> query, ProductFilters filters)
        {
            query = filters.MinPrice != default && filters.MaxPrice != default ?
                query.Where(q => q.Price >= filters.MinPrice && q.Price <= filters.MaxPrice) :
                filters.MinPrice != default ? query.Where(q => q.Price >= filters.MinPrice) :
                filters.MaxPrice != default ? query.Where(q => q.Price <= filters.MaxPrice) : query;

            query = filters.Type.Length >= 2 ? query.Where(q => filters.Type.Select(t => t.ToUpper()).Contains(q.Type.ToUpper())) : query;

            return query;
        }
    }
}
