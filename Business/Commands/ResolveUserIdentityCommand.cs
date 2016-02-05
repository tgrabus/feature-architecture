using System.Security.Claims;

namespace Business.Commands
{
    public class ResolveUserIdentityCommand : ICommand
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class ResolveUserIdentityCommandResult : ICommandResult
    {
        public ClaimsIdentity Identity { get; set; }
    }
}