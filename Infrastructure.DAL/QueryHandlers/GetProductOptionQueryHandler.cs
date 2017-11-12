using System;
using System.Data.Entity;
using System.Linq;
using Application.Common;
using Application.Core.Dtos;
using Application.Core.Queries;
using Domain.Core;
using Infrastructure.DAL.EF;

namespace Infrastructure.DAL.QueryHandlers
{
    public class GetProductOptionQueryHandler: IQueryHandler<GetProductOptionQuery, ProductOptionDto>
    {
        private readonly IDbQueryable _dbContext;

        public GetProductOptionQueryHandler(IDbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
            _dbContext = dbContext;
        }

        public ProductOptionDto HandleQuery(GetProductOptionQuery query)
        {
            var result = _dbContext.GetSet<ProductOption>().Include(x => x.Product)
                .FirstOrDefault(h => h.Id.Equals(query.Id));

            if(result == null) return new ProductOptionDto();

            return new ProductOptionDto
            {
                Description = result.Description,
                Id = result.Id,
                Name = result.Name,
                ProductId = result.Product.Id
            };
        }
    }
}