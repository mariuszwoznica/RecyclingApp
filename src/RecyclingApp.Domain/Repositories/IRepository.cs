using RecyclingApp.Domain.Primitives;
using System;
using System.Threading.Tasks;

namespace RecyclingApp.Domain.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(Guid id);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> SaveChangesAsync();
}
