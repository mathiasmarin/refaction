using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Common;
using Application.Core.Commands;
using Application.Core.Dtos;
using Application.Core.Queries;

namespace refactor_me.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly ICommandHandler<DeleteProductCommand> _deleteProductCommandHandler;
        private readonly IQueryHandler<GetProductOptionsForProductQuery, ICollection<ProductOptionDto>> _getproductOptionsQueryHandler;
        private readonly ICommandHandler<UpdateProductsCommand> _updateProductsCommandHandler;
        private readonly ICommandHandler<AddNewProductCommand> _addNewProductCommandHandler;
        private readonly IQueryHandler<GetProductByIdQuery, ProductDto> _getProductByIdQueryHandler;
        private readonly IQueryHandler<GetProductByNameQuery, ProductDto> _getProductByNameQueryHandler;
        private readonly IQueryHandler<GetAllProductsQuery, ICollection<ProductDto>> _getAllProductsQueryHandler;

        public ProductsController(IQueryHandler<GetAllProductsQuery, ICollection<ProductDto>> getAllProductsQueryHandler,
            IQueryHandler<GetProductByNameQuery, ProductDto> getProductByNameQueryHandler, IQueryHandler<GetProductByIdQuery, ProductDto> getProductByIdQueryHandler,
            ICommandHandler<AddNewProductCommand> addNewProductCommandHandler, ICommandHandler<UpdateProductsCommand> updateProductsCommandHandler,
            ICommandHandler<DeleteProductCommand> deleteProductCommandHandler, IQueryHandler<GetProductOptionsForProductQuery, ICollection<ProductOptionDto>> getproductOptionsQueryHandler)
        {
            if (getAllProductsQueryHandler == null) throw new ArgumentNullException(nameof(getAllProductsQueryHandler));
            if (getProductByNameQueryHandler == null)
                throw new ArgumentNullException(nameof(getProductByNameQueryHandler));
            if (getProductByIdQueryHandler == null) throw new ArgumentNullException(nameof(getProductByIdQueryHandler));
            if (addNewProductCommandHandler == null)
                throw new ArgumentNullException(nameof(addNewProductCommandHandler));
            if (updateProductsCommandHandler == null)
                throw new ArgumentNullException(nameof(updateProductsCommandHandler));
            if (deleteProductCommandHandler == null)
                throw new ArgumentNullException(nameof(deleteProductCommandHandler));
            if (getproductOptionsQueryHandler == null)
                throw new ArgumentNullException(nameof(getproductOptionsQueryHandler));
           _deleteProductCommandHandler = deleteProductCommandHandler;
            _getproductOptionsQueryHandler = getproductOptionsQueryHandler;
            _updateProductsCommandHandler = updateProductsCommandHandler;
            _addNewProductCommandHandler = addNewProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _getProductByNameQueryHandler = getProductByNameQueryHandler;
            _getAllProductsQueryHandler = getAllProductsQueryHandler;
        }

        [Route]
        [HttpGet]
        public ICollection<ProductDto> GetAll()
        {
            return _getAllProductsQueryHandler.HandleQuery(new GetAllProductsQuery());
        }

        [Route("Name/{Name}")]
        [HttpGet]
        public ProductDto SearchByName([FromUri]GetProductByNameQuery query)
        {
            return _getProductByNameQueryHandler.HandleQuery(query);
        }

        [Route("{id}")]
        [HttpGet]
        public ProductDto GetProduct([FromUri]GetProductByIdQuery query)
        {
            return _getProductByIdQueryHandler.HandleQuery(query);
        }

        [Route("Create")]
        [HttpPost]
        public void Create([FromBody]AddNewProductCommand command)
        {
            _addNewProductCommandHandler.Execute(command);
        }

        [Route("{id}")]
        [HttpPut]
        public void Update([FromBody]UpdateProductsCommand command)
        {
            _updateProductsCommandHandler.Execute(command);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete([FromUri]DeleteProductCommand command)
        {
            _deleteProductCommandHandler.Execute(command);
        }

        [Route("{ProductId}/options")]
        [HttpGet]
        public ICollection<ProductOptionDto> GetOptions([FromUri]GetProductOptionsForProductQuery forProductQuery)
        {
            return _getproductOptionsQueryHandler.HandleQuery(forProductQuery);
        }
       
    }
}
