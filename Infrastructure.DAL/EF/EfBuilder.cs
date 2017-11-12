using System.Data.Entity;
using Infrastructure.DAL.EF.Mappings;

namespace Infrastructure.DAL.EF
{
    public static class EfBuilder
    {
        public static void BuildDb(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductOptionMap());
            modelBuilder.Configurations.Add(new ProductsMap());
        }
    }
}
