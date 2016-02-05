using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Business.Commands;

namespace Business.Dispatchers
{
    [ContractClass(typeof(CommandDispatcherAsyncContract))]
    public interface ICommandDispatcherAsync
    {
        Task<ICommandResult> ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }

    [ContractClassFor(typeof(ICommandDispatcherAsync))]
    internal abstract class CommandDispatcherAsyncContract : ICommandDispatcherAsync
    {
        public Task<ICommandResult> ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            Contract.Requires<ArgumentNullException>(command != null);
            return Task.FromResult(default(ICommandResult));
        }
    }
}