using RecyclingApp.Domain.Model;
using System;
using System.Threading.Tasks;

namespace RecyclingApp.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetWithItemsAsync(Guid id);
    }
}
