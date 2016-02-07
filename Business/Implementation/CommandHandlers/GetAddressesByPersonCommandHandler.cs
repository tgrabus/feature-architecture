using System;
using System.Linq;
using System.Threading.Tasks;
using Business.CommandHandlers;
using Business.Commands;
using DataAccess.DbContexts;
using DataAccess.Queries;

namespace Business.Implementation.CommandHandlers
{
    public class GetAddressesByPersonCommandHandler : 
        ICommandHandler<GetAddressesByPersonCommand>,
        ICommandHandlerAsync<GetAddressesByPersonCommand>
    {
        private readonly IAppContextAdapter context;

        public GetAddressesByPersonCommandHandler(IAppContextAdapter context)
        {
            this.context = context;
        }

        public ICommandResult Execute(GetAddressesByPersonCommand command)
        {
            AssertThatArgumentIsValid(command);

            var query = new GetAddressesByPersonIdQuery()
            {
                PersonId = command.PersonId
            };

            var result = context.Select(query) as GetAddressesByPersonIdQueryResult;

            if (result == null)
            {
                throw new NullReferenceException();
            }

            return new GetAddressesByPersonCommandResult()
            {
                PersonId = result.PersonId,
                Addresses = result.Addresses?.Select(x => new PersonAddress()
                {
                    City = x.City,
                    Street = x.Street
                })
            };
        }

        public async Task<ICommandResult> ExecuteAsync(GetAddressesByPersonCommand command)
        {
            AssertThatArgumentIsValid(command);

            var query = new GetAddressesByPersonIdQuery()
            {
                PersonId = command.PersonId
            };

            var result = await context.SelectAsync(query) as GetAddressesByPersonIdQueryResult;

            return new GetAddressesByPersonCommandResult()
            {
                PersonId = result.PersonId,
                Addresses = result.Addresses.Select(address => new PersonAddress()
                {
                    City = address.City,
                    Street = address.Street
                })
            };
        }

        private void AssertThatArgumentIsValid(GetAddressesByPersonCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            if (command.PersonId <= 0)
            {
                throw new InvalidOperationException(nameof(command));
            }
        }
    }
}