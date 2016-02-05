using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Identity.Entities
{
    internal class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
    }
}