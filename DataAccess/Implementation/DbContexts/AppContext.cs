using System.Data.Entity;
using DataAccess.DbContexts;
using DataAccess.Identity.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.Entities.AppContext;

namespace DataAccess.Implementation.DbContexts
{
    internal class AppContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole, int,
        ApplicationUserLogin,
        ApplicationUserRole,
        ApplicationUserClaim>, IAppContext
    {
        public AppContext() : base("name=AppContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual IDbSet<Person> Persons { get; set; }
        public virtual IDbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}