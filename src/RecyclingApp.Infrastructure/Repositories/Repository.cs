using Microsoft.EntityFrameworkCore;
using RecyclingApp.Domain.Primitives;
using RecyclingApp.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace RecyclingApp.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> 
    where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context) 
        => _context = context;

    public async Task<TEntity?> GetAsync(Guid id)
        => await _context.Set<TEntity>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);

    public void Add(TEntity entity) 
        => _context.Add(entity);

    public void Update(TEntity entity) 
        => _context.Update(entity);

    public void Delete(TEntity entity) 
        => _context.Remove(entity);

    public async Task SaveChangesAsync() 
        => await _context.SaveChangesAsync();
}