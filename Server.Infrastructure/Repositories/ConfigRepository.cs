using Microsoft.EntityFrameworkCore;
using Server.Application.Commons;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class ConfigRepository<TEntity> : IConfigRepository<TEntity> where TEntity : ConfigEntity
    {
        protected DbSet<TEntity> _dbSet;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public ConfigRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService)
        {
            _dbSet = context.Set<TEntity>();
            _timeService = timeService;
            _claimsService = claimsService;
        }
        public Task<List<TEntity>> GetAllAsync() => _dbSet.ToListAsync();

        public async Task AddAsync(TEntity entity)
        {
            entity.CreationDate = _timeService.GetCurrentTime();
            entity.CreatedBy = _claimsService.GetCurrentUserId;
            await _dbSet.AddAsync(entity);
        }

        public void SoftRemove(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletionDate = _timeService.GetCurrentTime();
            entity.DeleteBy = _claimsService.GetCurrentUserId;
            _dbSet.Update(entity);
        }
        public void HardRemove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public void Update(TEntity entity)
        {
            entity.ModificationDate = _timeService.GetCurrentTime();
            entity.ModificationBy = _claimsService.GetCurrentUserId;
            _dbSet.Update(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreationDate = _timeService.GetCurrentTime();
                entity.CreatedBy = _claimsService.GetCurrentUserId;
            }
            await _dbSet.AddRangeAsync(entities);
        }

        public void SoftRemoveRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletionDate = _timeService.GetCurrentTime();
                entity.DeleteBy = _claimsService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
        }

        public async Task<Pagination<TEntity>> ToPagination(int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await _dbSet.CountAsync();
            var items = await _dbSet.OrderByDescending(x => x.CreationDate)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<TEntity>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };

            return result;
        }

        public void UpdateRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreationDate = _timeService.GetCurrentTime();
                entity.CreatedBy = _claimsService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
        }
    }
}

