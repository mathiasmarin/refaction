using System.Threading.Tasks;
using Domain.Common;

namespace Infrastructure.DAL.EF
{
    public interface IDbContext : IDbQueryable
    {
        Task<int> SaveAsync();
        void SaveSync();
        void Modify<TEntity>(TEntity item) where TEntity : Entity;

    }
}