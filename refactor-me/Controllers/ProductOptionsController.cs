using System;
using System.Web.Http;
using Application.Common;
using Application.Core.Commands;
using Application.Core.Dtos;
using Application.Core.Queries;

namespace refactor_me.Controllers
{
    [RoutePrefix("api/producOptions")]
    public class ProductOptionsController : ApiController
    {
        private readonly IQueryHandler<GetProductOptionQuery, ProductOptionDto> _getProductOptionByIdQueryHandler;
        private readonly ICommandHandler<AddNewProductOptionCommand> _addNewProcutOptionCommandHandler;
        private readonly ICommandHandler<UpdateProductOptionCommand> _updateProductOptionCommandHandler;
        private readonly ICommandHandler<DeleteProductOptionCommand> _deleteProductOptionCommandHandler;

        public ProductOptionsController(IQueryHandler<GetProductOptionQuery, ProductOptionDto> getProductOptionByIdQueryHandler, 
            ICommandHandler<AddNewProductOptionCommand> addNewProcutOptionCommandHandler,
            ICommandHandler<UpdateProductOptionCommand> updateProductOptionCommandHandler,
            ICommandHandler<DeleteProductOptionCommand> deleteProductOptionCommandHandler)
        {
            if (getProductOptionByIdQueryHandler == null)
                throw new ArgumentNullException(nameof(getProductOptionByIdQueryHandler));
            if (addNewProcutOptionCommandHandler == null)
                throw new ArgumentNullException(nameof(addNewProcutOptionCommandHandler));
            if (updateProductOptionCommandHandler == null)
                throw new ArgumentNullException(nameof(updateProductOptionCommandHandler));
            if (deleteProductOptionCommandHandler == null)
                throw new ArgumentNullException(nameof(deleteProductOptionCommandHandler));
            _getProductOptionByIdQueryHandler = getProductOptionByIdQueryHandler;
            _addNewProcutOptionCommandHandler = addNewProcutOptionCommandHandler;
            _updateProductOptionCommandHandler = updateProductOptionCommandHandler;
            _deleteProductOptionCommandHandler = deleteProductOptionCommandHandler;
        }
        [Route("{id}")]
        [HttpGet]
        public ProductOptionDto GetOption([FromUri]GetProductOptionQuery query)
        {
            return _getProductOptionByIdQueryHandler.HandleQuery(query);
        }
        [Route("Create")]
        [HttpPost]
        public void CreateOption([FromBody]AddNewProductOptionCommand command)
        {
            _addNewProcutOptionCommandHandler.Execute(command);
        }

        [Route("{id}")]
        [HttpPut]
        public void UpdateOption([FromBody]UpdateProductOptionCommand command)
        {
           _updateProductOptionCommandHandler.Execute(command);
        }

        [Route("{id}")]
        [HttpDelete]
        public void DeleteOption([FromUri] DeleteProductOptionCommand command)
        {
           _deleteProductOptionCommandHandler.Execute(command);
        }
    }
}