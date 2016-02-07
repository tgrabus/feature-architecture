using System.Data.Entity;
using DataAccess.DbContexts;
using Models.Entities.AppContext;

namespace DataAccess.Implementation.DbContexts
{
    internal class AppContext : DbContext, IAppContext
    {
        public AppContext() : base("name=AppContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual IDbSet<Person> Persons { get; set; }
        public virtual IDbSet<Address> Addresses { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}