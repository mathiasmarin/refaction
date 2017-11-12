using Application.Common;
using Application.Core.Commands;
using Domain.Common;
using Domain.Core;

namespace Application.Core.CommandHandlers
{
    public class DeleteProductOptionCommandHandler:ICommandHandler<DeleteProductOptionCommand>
    {
        private readonly IRepository<ProductOption> _productOptionRepository;

        public DeleteProductOptionCommandHandler(IRepository<ProductOption> productOptionRepository)
        {
            _productOptionRepository = productOptionRepository;
        }

        public void Execute(DeleteProductOptionCommand command)
        {
            var option = _productOptionRepository.Get(command.Id);

            _productOptionRepository.Remove(option);

            _productOptionRepository.SaveChanges();
        }
    }
}