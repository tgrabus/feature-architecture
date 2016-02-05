using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Identity;
using DataAccess.Identity.Entities;
using Microsoft.AspNet.Identity;
using Models.Entities.AppContext;

namespace DataAccess.Implementation.Identity
{
    internal class UserManagerAdapter : IUserManagerAdapter
    {
        private readonly IApplicationUserManager adaptee;
        private readonly IMappingEngine mapper;

        public UserManagerAdapter(IApplicationUserManager adaptee, IMappingEngine mapper)
        {
            this.adaptee = adaptee;
            this.mapper = mapper;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await adaptee.FindByEmailAsync(email);
            return mapper.Map<User>(user);
        } 

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var applicationUser = mapper.Map<ApplicationUser>(user);
            return await adaptee.CheckPasswordAsync(applicationUser, password);
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType)
        {
            var applicationUser = mapper.Map<ApplicationUser>(user);
            return await adaptee.CreateIdentityAsync(applicationUser, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}