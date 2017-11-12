using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common;
using Application.Core.Dtos;
using Application.Core.Queries;
using Domain.Core;
using Infrastructure.DAL.EF;

namespace Infrastructure.DAL.QueryHandlers
{
    public class GetAllProductsQueryHandler:IQueryHandler<GetAllProductsQuery,ICollection<ProductDto>>
    {
        private readonly IDbQueryable _dbContext;

        public GetAllProductsQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public ICollection<ProductDto> HandleQuery(GetAllProductsQuery query)
        {
            return _dbContext.GetSet<Product>().Select(x => new ProductDto
            {
                Id = x.Id,
                DeliveryPrice = x.DeliveryPrice,
                Description = x.Description,
                Name = x.Name,
                Price = x.Price
            }).ToList();
        }
    }
}
