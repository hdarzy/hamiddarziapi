using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool savenow = true);
        ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    }
}