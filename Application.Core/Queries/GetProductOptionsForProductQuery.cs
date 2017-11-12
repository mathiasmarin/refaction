using System;
using System.Collections.Generic;
using Application.Common;
using Application.Core.Dtos;

namespace Application.Core.Queries
{
    public class GetProductOptionsForProductQuery : IQuery<ICollection<ProductOptionDto>>
    {
        public Guid ProductId { get; set; }
    }
}