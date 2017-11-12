using System.Data.Entity.ModelConfiguration;
using Domain.Core;

namespace Infrastructure.DAL.EF.Mappings
{
    public class ProductsMap : EntityTypeConfiguration<Product>
    {
        public ProductsMap()
        {
            ToTable("Product");
        }
    }
}