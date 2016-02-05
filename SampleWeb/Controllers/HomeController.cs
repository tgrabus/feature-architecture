using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Business.CommandHandlers;
using Business.Commands;

namespace SampleWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandHandler<GetAddressesByPersonCommand> getPersonAddressesCommandHandler;
        private readonly ICommandHandlerAsync<GetAddressesByPersonCommand> getPersonAddressesCommandHandlerAsync;

        public HomeController(ICommandHandler<GetAddressesByPersonCommand> getPersonAddressesCommandHandler,
            ICommandHandlerAsync<GetAddressesByPersonCommand> getPersonAddressesCommandHandlerAsync)
        {
            this.getPersonAddressesCommandHandler = getPersonAddressesCommandHandler;
            this.getPersonAddressesCommandHandlerAsync = getPersonAddressesCommandHandlerAsync;
        }

        public ActionResult Index()
        {
            var result = getPersonAddressesCommandHandler.Execute(new GetAddressesByPersonCommand()
            {
                PersonId = 2
            });

            return View(result);
        }

        public async Task<ActionResult> Empty()
        {
            var result = await getPersonAddressesCommandHandlerAsync.ExecuteAsync(new GetAddressesByPersonCommand()
            {
                PersonId = 2
            }) as GetAddressesByPersonCommandResult;

            return Content(result.Addresses.Count().ToString());
        }
    }
}