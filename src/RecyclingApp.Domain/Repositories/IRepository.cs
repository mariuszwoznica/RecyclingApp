using RecyclingApp.Domain.Primitives;
using System;
using System.Threading.Tasks;

namespace RecyclingApp.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetAsync(Guid id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task SaveChangesAsync();
}
