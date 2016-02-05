using System.Security.Authentication;
using System.Threading.Tasks;
using Business.CommandHandlers;
using Business.Commands;
using DataAccess.Identity;
using Microsoft.AspNet.Identity;

namespace Business.Implementation.CommandHandlers
{
    public class ResolveUserIdentityCommandHandler : ICommandHandlerAsync<ResolveUserIdentityCommand>
    {
        private readonly IUserManagerAdapter userManager;

        public ResolveUserIdentityCommandHandler(IUserManagerAdapter userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ICommandResult> ExecuteAsync(ResolveUserIdentityCommand command)
        {
            var user = await userManager.FindByEmailAsync(command.Email);

            if (!await userManager.CheckPasswordAsync(user, command.Password))
            {
                throw new AuthenticationException();
            }

            var identity = await userManager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie);

            return new ResolveUserIdentityCommandResult()
            {
                Identity = identity
            };
        }
    }
}