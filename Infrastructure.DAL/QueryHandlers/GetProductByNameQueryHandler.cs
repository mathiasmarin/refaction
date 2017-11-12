using System;
using System.Linq;
using Application.Common;
using Application.Core.Dtos;
using Application.Core.Queries;
using Domain.Core;
using Infrastructure.DAL.EF;

namespace Infrastructure.DAL.QueryHandlers
{
    public class GetProductByNameQueryHandler: IQueryHandler<GetProductByNameQuery, ProductDto>
    {
        private readonly IDbQueryable _dbContext;
        public GetProductByNameQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public ProductDto HandleQuery(GetProductByNameQuery query)
        {
            var match = _dbContext.GetSet<Product>().FirstOrDefault(x => x.Name.Equals(query.Name));

            if (match == null) return new ProductDto();

            return new ProductDto
            {
                Description = match.Description,
                DeliveryPrice = match.DeliveryPrice,
                Id = match.Id,
                Name = match.Name,
                Price = match.Price
            };

        }
    }
}