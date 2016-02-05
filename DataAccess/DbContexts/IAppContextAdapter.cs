using System.Threading.Tasks;
using DataAccess.Queries;

namespace DataAccess.DbContexts
{
    public interface IAppContextAdapter
    {
        QueryResult Select(Query query);
        Task<QueryResult> SelectAsync(Query query);
        TEntity Insert<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        void Save();
        Task<int> SaveAsync();
    }
}