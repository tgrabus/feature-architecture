using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.DbContexts
{
    public interface IAppContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}