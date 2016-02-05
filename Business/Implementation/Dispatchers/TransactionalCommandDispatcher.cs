using System.Transactions;
using Business.Commands;
using Business.Dispatchers;

namespace Business.Implementation.Dispatchers
{
    public class TransactionalCommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandDispatcher next;

        public TransactionalCommandDispatcher(ICommandDispatcher next)
        {
            this.next = next;
        }

        public ICommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            using (var transaction = new TransactionScope())
            {
                var result = next.Execute(command);
                transaction.Complete();
                return result;
            }
        }
    }
}