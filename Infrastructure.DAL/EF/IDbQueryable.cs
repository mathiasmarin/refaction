using System.Data.Entity;
using Domain.Common;

namespace Infrastructure.DAL.EF
{
    public interface IDbQueryable
    {
        DbSet<TEntity> GetSet<TEntity>() where TEntity : Entity;

    }
}