using System;
using Application.Common;
using Application.Core.Commands;
using Domain.Common;
using Domain.Core;

namespace Application.Core.CommandHandlers
{
    public class DeleteProductCommandHandler:ICommandHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public DeleteProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute(DeleteProductCommand command)
        {
            var product = _productRepository.Get(command.Id);

            _productRepository.Remove(product);

            _productRepository.SaveChanges();
        }
    }
}