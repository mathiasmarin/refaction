using System;
using Application.Common;
using Application.Core.Commands;
using Domain.Common;
using Domain.Core;

namespace Application.Core.CommandHandlers
{
    public class UpdateProductOptionCommandHandler:ICommandHandler<UpdateProductOptionCommand>
    {
        private readonly IRepository<ProductOption> _productOptionRepository;

        public UpdateProductOptionCommandHandler(IRepository<ProductOption> productOptionRepository)
        {
            if (productOptionRepository == null) throw new ArgumentNullException(nameof(productOptionRepository));
            _productOptionRepository = productOptionRepository;
        }

        public void Execute(UpdateProductOptionCommand command)
        {
            var existing = _productOptionRepository.Get(command.Id);

            if (!existing.Description.Equals(command.Description))
            {
                existing.UpdateDescription(command.Description);
            }
            if (!existing.Name.Equals(command.Name))
            {
                existing.UpdateName(command.Name);
            }
            _productOptionRepository.Modify(existing);

            _productOptionRepository.SaveChanges();
        }
    }
}