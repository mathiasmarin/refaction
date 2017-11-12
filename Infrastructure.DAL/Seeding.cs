using System.Data.Entity.Migrations;
using Domain.Core;
using Infrastructure.DAL.EF;

namespace Infrastructure.DAL
{
    public class Seeding : DbMigrationsConfiguration<ProductDbContext>
    {
        public Seeding()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProductDbContext context)
        {
            var samsung = new Product("Samsung Galaxy S7", "Newest mobile product from Samsung.", (decimal) 1024.99,
                (decimal) 16.99);

            var apple = new Product("Apple iPhone 6S", "Newest mobile product from Apple.", (decimal)1299.99,
                (decimal)15.99);

            var samsungOption1 = new ProductOption(samsung, "White", "White Samsung Galaxy S7");
            var samsungOption2 = new ProductOption(samsung, "Black", "Black Samsung Galaxy S7");


            var appleOption1 = new ProductOption(apple, "Rose Gold", "Gold Apple iPhone 6S");
            var appleOption2 = new ProductOption(apple, "White", "White Apple iPhone 6S");
            var appleOption3 = new ProductOption(apple, "Black", "Black Apple iPhone 6S");

            context.GetSet<Product>().Add(samsung);
            context.GetSet<Product>().Add(apple);

            context.SaveChanges();

            context.GetSet<ProductOption>().Add(samsungOption1);
            context.GetSet<ProductOption>().Add(samsungOption2);
            context.GetSet<ProductOption>().Add(appleOption1);
            context.GetSet<ProductOption>().Add(appleOption2);
            context.GetSet<ProductOption>().Add(appleOption3);

            context.SaveChanges();

        }
    }
}