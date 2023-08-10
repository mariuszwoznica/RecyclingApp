using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
