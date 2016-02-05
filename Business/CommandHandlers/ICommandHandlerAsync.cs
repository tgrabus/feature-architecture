using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Business.Commands;

namespace Business.CommandHandlers
{
    [ContractClass(typeof(CommandHandlerAsyncContract<>))]
    public interface ICommandHandlerAsync<TCommand> where TCommand : ICommand
    {
        Task<ICommandResult> ExecuteAsync(TCommand command);
    }

    [ContractClassFor(typeof(ICommandHandlerAsync<>))]
    internal abstract class CommandHandlerAsyncContract<TCommand> : ICommandHandlerAsync<TCommand>
        where TCommand : ICommand
    {
        public Task<ICommandResult> ExecuteAsync(TCommand command)
        {
            Contract.Requires<ArgumentNullException>(command != null);

            return Task.FromResult(default(ICommandResult));
        }
    }
}