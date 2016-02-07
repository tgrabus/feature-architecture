using System.Data.Entity;
using DataAccess.Identity.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Implementation.DbContexts
{
    internal class IdentityContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole, int,
        ApplicationUserLogin,
        ApplicationUserRole,
        ApplicationUserClaim>
    {
        public IdentityContext() : base("name=AppContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
        }
    }
}