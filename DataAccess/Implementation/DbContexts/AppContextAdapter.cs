using System.Threading.Tasks;
using DataAccess.DbContexts;
using DataAccess.Queries;

namespace DataAccess.Implementation.DbContexts
{
    internal class AppContextAdapter : IAppContextAdapter
    {
        private readonly IAppContext adaptee;

        public AppContextAdapter(IAppContext adaptee)
        {
            this.adaptee = adaptee;
        }

        public void Save()
        {
            adaptee.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return adaptee.SaveChangesAsync();
        }

        public QueryResult Select(Query query)
        {
            return query.Execute(adaptee);
        }

        public Task<QueryResult> SelectAsync(Query query)
        {
            return query.ExecuteAsync(adaptee);
        } 

        public TEntity Insert<TEntity>(TEntity entity) where TEntity : class
        {
            var set = adaptee.Set<TEntity>();
            set.Add(entity);
            return entity;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            var set = adaptee.Set<TEntity>();
            set.Remove(entity);
        }
    }
}