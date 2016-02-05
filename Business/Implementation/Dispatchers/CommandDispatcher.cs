using System;
using System.Threading.Tasks;
using Autofac;
using Business.CommandHandlers;
using Business.Commands;
using Business.Dispatchers;

namespace Business.Implementation.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher, ICommandDispatcherAsync
    {
        private readonly IComponentContext resolver;

        public CommandDispatcher(IComponentContext resolver)
        {
            this.resolver = resolver;
        }

        public ICommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var handler = resolver.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
            {
                throw new NotImplementedException();
            }

            return handler.Execute(command);
        }

        public async Task<ICommandResult>  ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var handler = resolver.Resolve<ICommandHandlerAsync<TCommand>>();

            if (handler == null)
            {
                throw new NotImplementedException();
            }

            return await handler.ExecuteAsync(command);
        }
    }
}