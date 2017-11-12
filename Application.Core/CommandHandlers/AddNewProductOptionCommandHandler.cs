using System;
using Application.Common;
using Application.Core.Commands;
using Domain.Common;
using Domain.Core;

namespace Application.Core.CommandHandlers
{
    public class AddNewProductOptionCommandHandler: ICommandHandler<AddNewProductOptionCommand>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductOption> _productOptionRepository;

        public AddNewProductOptionCommandHandler(IRepository<Product> productRepository, IRepository<ProductOption> productOptionRepository)
        {
            if (productRepository == null) throw new ArgumentNullException(nameof(productRepository));
            if (productOptionRepository == null) throw new ArgumentNullException(nameof(productOptionRepository));
            _productRepository = productRepository;
            _productOptionRepository = productOptionRepository;
        }

        public void Execute(AddNewProductOptionCommand command)
        {
            var product = _productRepository.Get(command.ProductId);

            var newOption = new ProductOption(product,command.Name,command.Description);

            _productOptionRepository.Add(newOption);

            _productRepository.SaveChanges();
        }
    }
}