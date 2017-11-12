using Application.Common;
using Application.Core.Dtos;

namespace Application.Core.Queries
{
    public class GetProductByNameQuery : IQuery<ProductDto>
    {
        public string Name { get; set; }
    }
}