using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Configuration;
using Domain.Common;

namespace Infrastructure.DAL.EF
{
    public class ProductDbContext : DbContext, IDbContext
    {
        public ProductDbContext() : base(WebConfigurationManager.ConnectionStrings["Main"].ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EfBuilder.BuildDb(modelBuilder);
        }

        public DbSet<TEntity> GetSet<TEntity>() where TEntity : Entity
        {
            return Set<TEntity>();

        }

        public async Task<int> SaveAsync()
        {
            return await SaveChangesAsync();
        }

        public void SaveSync()
        {
            SaveChanges();
        }

        public void Modify<TEntity>(TEntity item) where TEntity : Entity
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}