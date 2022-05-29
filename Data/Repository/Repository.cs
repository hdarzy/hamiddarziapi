using Common.Utilities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public  class Repository<TEntity> : IRepository<TEntity> where TEntity : class , IEntity
    {
        protected readonly ApplicationDbContext Dbcontext;
        public DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public Repository(ApplicationDbContext dbcontext)
        {
            Dbcontext = dbcontext;
            Entities = Dbcontext.Set<TEntity>();
        }

        #region Async Methods
        public virtual ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken ,params object [] ids)
        {
            return Entities.FindAsync(ids, cancellationToken);
        }

        public virtual async Task AddAsync (TEntity entity , CancellationToken cancellationToken , bool savenow=true)
        {
            Assert.NotNull(entity, nameof(entity));
            await Entities.AddAsync(entity,cancellationToken ).ConfigureAwait(false);
        }

        #endregion
    }
}
