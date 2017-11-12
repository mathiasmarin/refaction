using System;
using Application.Common;
using Application.Core.Commands;
using Domain.Common;
using Domain.Core;

namespace Application.Core.CommandHandlers
{
    public class UpdateProductsCommandHandler:ICommandHandler<UpdateProductsCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public UpdateProductsCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute(UpdateProductsCommand command)
        {
            var product = _productRepository.Get(command.Id);

            if (!product.Name.Equals(command.Name))
            {
                product.UpdateName(command.Name);
            }
            if (!product.DeliveryPrice.Equals(command.DeliveryPrice))
            {
                product.UpdateDeliveryPrice(command.DeliveryPrice);
            }
            if (!product.Description.Equals(command.Description))
            {
                product.UpdateDescription(command.Description);
            }
            if (!product.Price.Equals(command.Price))
            {
                product.UpdatePrice(command.Price);
            }
            _productRepository.Modify(product);

            _productRepository.SaveChanges();
        }
    }
}