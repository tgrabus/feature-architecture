using System;
using System.Diagnostics.Contracts;
using Business.Commands;

namespace Business.Dispatchers
{
    [ContractClass(typeof(CommandDispatcherContract))]
    public interface ICommandDispatcher
    {
        ICommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }

    [ContractClassFor(typeof(ICommandDispatcher))]
    internal abstract class CommandDispatcherContract : ICommandDispatcher
    {
        public ICommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            Contract.Requires<ArgumentNullException>(command != null);
            Contract.Ensures(Contract.Result<ICommandResult>() != null);
            return default(ICommandResult);
        }
    }
}