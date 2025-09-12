﻿using Server.Domain.Entities;
using Server.Application.Commons;
using System.Linq.Expressions;

namespace Server.Application.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void SoftRemove(TEntity entity);
        void HardRemove(TEntity entity);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddRangeAsync(List<TEntity> entities);
        void SoftRemoveRange(List<TEntity> entities);

        Task<Pagination<TEntity>> ToPagination(int pageNumber = 0, int pageSize = 10);
    }
}
