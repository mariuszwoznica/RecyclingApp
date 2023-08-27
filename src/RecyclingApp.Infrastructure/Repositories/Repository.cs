﻿using RecyclingApp.Domain.Primitives;
using RecyclingApp.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace RecyclingApp.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly ApplicationContext _context;

    public Repository(ApplicationContext context) 
        => _context = context;

    public async Task<T> GetByIdAsync(Guid id) 
        => await _context.FindAsync<T>(id);

    public void Add(T entity) 
        => _context.Add(entity);

    public void Update(T entity) 
        => _context.Update(entity);

    public void Remove(T entity) 
        => _context.Remove(entity);

    public async Task<bool> SaveChangesAsync() 
        => (await _context.SaveChangesAsync() > 0);
}