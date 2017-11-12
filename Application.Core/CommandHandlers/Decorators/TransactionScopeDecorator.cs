using System.Transactions;
using Application.Common;

namespace Application.Core.CommandHandlers.Decorators
{
    public class TransactionScopeDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _decorated;

        public TransactionScopeDecorator(ICommandHandler<TCommand> decorated)
        {
            _decorated = decorated;
        }

        public void Execute(TCommand command)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,TransactionManager.DefaultTimeout))
            {
                 _decorated.Execute(command);

                 scope.Complete();
            }
        }
    }
}