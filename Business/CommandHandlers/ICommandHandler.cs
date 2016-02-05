using System;
using System.Diagnostics.Contracts;
using Business.Commands;

namespace Business.CommandHandlers
{
    [ContractClass(typeof(CommandHandlerContract<>))]
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        ICommandResult Execute(TCommand command);
    }

    [ContractClassFor(typeof(ICommandHandler<>))]
    internal abstract class CommandHandlerContract<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public ICommandResult Execute(TCommand command)
        {
            Contract.Requires<ArgumentNullException>(command != null);
            Contract.Ensures(Contract.Result<ICommandResult>() != null);
            return default(ICommandResult);
        }
    }
}