using Microsoft.EntityFrameworkCore;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model;
using RecyclingApp.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace RecyclingApp.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context) { }

        public async Task<Order> GetWithItemsAsync(Guid id)
        {
            return await _context.Orders.Include("OrderItems").FirstAsync(o => o.Id == id);
        }
    }
}
