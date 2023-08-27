using Microsoft.EntityFrameworkCore;
using RecyclingApp.Domain.Entities.Orders;
using RecyclingApp.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace RecyclingApp.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationContext context) : base(context) { }

    public async Task<Order> GetWithItemsAsync(Guid id)
        => await _context.Orders.Include("OrderItems").FirstAsync(o => o.Id == id);
}
