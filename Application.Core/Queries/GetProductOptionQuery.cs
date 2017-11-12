using System;
using Application.Common;
using Application.Core.Dtos;

namespace Application.Core.Queries
{
    public class GetProductOptionQuery : IQuery<ProductOptionDto>
    {
        public Guid Id { get; set; }
    }
}