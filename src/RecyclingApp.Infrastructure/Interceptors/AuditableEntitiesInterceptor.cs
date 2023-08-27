using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecyclingApp.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Infrastructure.Interceptors;

public sealed class AuditableEntitiesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default)
    {
        DbContext? dbContext = eventData.Context;

        if (dbContext is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        IEnumerable<EntityEntry<IAuditableEntity>> entries = 
            dbContext.ChangeTracker.Entries<IAuditableEntity>();

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
                entityEntry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Modified)
                entityEntry.Property(x => x.ModifiedAt).CurrentValue = DateTime.UtcNow;
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
