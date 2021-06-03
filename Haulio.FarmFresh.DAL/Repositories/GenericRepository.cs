using Haulio.FarmFresh.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly FarmFreshDbContext _farmFreshDbContext;
        public GenericRepository(FarmFreshDbContext farmFreshDbContext)
        {
            _farmFreshDbContext = farmFreshDbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var addedEntry = await _farmFreshDbContext.AddAsync(entity);
            await _farmFreshDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _farmFreshDbContext.AddRangeAsync(entity);
            await _farmFreshDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
            var addedEntry = _farmFreshDbContext.Remove(entity);
            return await _farmFreshDbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _farmFreshDbContext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _farmFreshDbContext.Set<TEntity>().ToListAsync() : _farmFreshDbContext.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var addedEntry = _farmFreshDbContext.Update(entity);
            await _farmFreshDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
            _farmFreshDbContext.UpdateRange(entity);
            await _farmFreshDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
