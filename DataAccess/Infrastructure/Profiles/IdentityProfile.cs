using AutoMapper;
using DataAccess.Identity.Entities;
using Models.Entities.AppContext;

namespace DataAccess.Infrastructure.Profiles
{
    public class IdentityProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUser, User>();
            CreateMap<User, ApplicationUser>();

            CreateMap<ApplicationRole, Role>();
            CreateMap<Role, ApplicationRole>();

            CreateMap<ApplicationUserClaim, UserClaim>();
            CreateMap<UserClaim, ApplicationUserClaim>();

            CreateMap<ApplicationUserLogin, UserLogin>();
            CreateMap<UserLogin, ApplicationUserLogin>();

            CreateMap<ApplicationUserRole, UserRole>();
            CreateMap<UserRole, ApplicationUserRole>();
        }
    }
}