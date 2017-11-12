using System;
using Application.Common;
using Application.Core.Commands;
using Domain.Common;
using Domain.Core;

namespace Application.Core.CommandHandlers
{
    public class AddNewProductCommandHandler: ICommandHandler<AddNewProductCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public AddNewProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute(AddNewProductCommand command)
        {
            var newProduct = new Product(command.Name,command.Description,command.Price,command.DeliveryPrice);

            _productRepository.Add(newProduct);

            _productRepository.SaveChanges();
        }
    }
}
