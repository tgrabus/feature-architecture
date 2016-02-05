using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Business.Commands;
using Business.Dispatchers;
using Microsoft.Owin.Security;

namespace SampleWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICommandDispatcher commandDispatcher;
        private readonly ICommandDispatcherAsync commandDispatcherAsync;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public AccountController(ICommandDispatcher commandDispatcher, 
            ICommandDispatcherAsync commandDispatcherAsync)
        {
            this.commandDispatcher = commandDispatcher;
            this.commandDispatcherAsync = commandDispatcherAsync;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var commandResult = await commandDispatcherAsync.ExecuteAsync(
                    new ResolveUserIdentityCommand()
                    {
                        Email = model.Email,
                        Password = model.Password
                    }) as ResolveUserIdentityCommandResult;

                AuthenticationManager.SignIn(
                    new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, commandResult.Identity);

                return RedirectToAction("Index", "Home");
            }
            catch(Exception exception)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}