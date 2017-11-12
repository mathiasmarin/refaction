using System.Data.Entity.ModelConfiguration;
using Domain.Core;

namespace Infrastructure.DAL.EF.Mappings
{
    public class ProductOptionMap : EntityTypeConfiguration<ProductOption>
    {
        public ProductOptionMap()
        {
            ToTable("ProductOption");
        }
    }
}