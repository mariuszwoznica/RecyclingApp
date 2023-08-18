using RecyclingApp.Domain.Entities.Orders;
using System;
using System.Threading.Tasks;

namespace RecyclingApp.Domain.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order> GetWithItemsAsync(Guid id);
}
