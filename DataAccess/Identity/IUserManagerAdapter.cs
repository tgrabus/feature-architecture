using System.Security.Claims;
using System.Threading.Tasks;
using Models.Entities.AppContext;

namespace DataAccess.Identity
{
    public interface IUserManagerAdapter
    {
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);
    }
}