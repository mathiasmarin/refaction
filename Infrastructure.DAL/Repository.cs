﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Common;
using Infrastructure.DAL.EF;

namespace Infrastructure.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IDbContext _dbContext;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(TEntity entity)
        {
            _dbContext.GetSet<TEntity>().Add(entity);
        }

        public TEntity Get(Guid id)
        {
            return _dbContext.GetSet<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] paths)
        {
            var result = _dbContext.GetSet<TEntity>().Where(filter);
            if (!paths.Any()) return result;
            foreach (var expression in paths)
            {
                result = result.Include(expression);
            }
            return result;
        }

        public void Remove(TEntity entity)
        {
            _dbContext.GetSet<TEntity>().Remove(entity);
        }

        public void Modify(TEntity entity)
        {
            _dbContext.GetSet<TEntity>();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveAsync() > 0;
        }

        public void SaveChanges()
        {
            _dbContext.SaveSync();
        }
    }
}