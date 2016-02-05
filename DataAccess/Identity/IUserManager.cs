using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Identity.Entities;
using Microsoft.AspNet.Identity;

namespace DataAccess.Identity
{
    internal interface IUserManager<TUser, TKey> : IDisposable
        where TUser : class, IUser<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TUser> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(TUser user, string password);
        Task<ClaimsIdentity> CreateIdentityAsync(TUser user, string authenticationType);
    }

    internal interface IApplicationUserManager : IUserManager<ApplicationUser, int>
    {
    }
}