using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Application.Common;
using Application.Core.Dtos;
using Application.Core.Queries;
using Domain.Core;
using Infrastructure.DAL.EF;

namespace Infrastructure.DAL.QueryHandlers
{
    public class GetProductOptionsQueryHandler:IQueryHandler<GetProductOptionsForProductQuery, ICollection<ProductOptionDto>>
    {
        private readonly IDbQueryable _dbContext;

        public GetProductOptionsQueryHandler(IDbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
            _dbContext = dbContext;
        }

        public ICollection<ProductOptionDto> HandleQuery(GetProductOptionsForProductQuery forProductQuery)
        {
            return _dbContext.GetSet<ProductOption>().Include(h => h.Product)
                .Where(x => x.Product.Id.Equals(forProductQuery.ProductId)).Select(p => new ProductOptionDto
                {
                    Id = p.Id,
                    Description = p.Description,
                    Name = p.Name,
                    ProductId = p.Product.Id
                }).ToList();
        }
    }
}