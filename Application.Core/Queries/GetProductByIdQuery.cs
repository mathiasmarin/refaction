using System;
using Application.Common;
using Application.Core.Dtos;

namespace Application.Core.Queries
{
    public class GetProductByIdQuery : IQuery<ProductDto>
    {
        public Guid Id { get; set; }
    }
}