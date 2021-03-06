﻿namespace Vanguard.Framework.Data.Repositories
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Vanguard.Framework.Core.Repositories;

    /// <summary>
    /// The repository class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="ReadRepository{TEntity}" />
    /// <seealso cref="IRepository{TEntity}" />
    public class Repository<TEntity> : ReadRepository<TEntity>, IRepository<TEntity>
        where TEntity : class, IDataEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public Repository(DbContext dbContext)
            : base(dbContext)
        {
            DbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

        /// <inheritdoc />
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <inheritdoc />
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        /// <inheritdoc />
        public int Save()
        {
            return DbContext.SaveChanges();
        }

        /// <inheritdoc />
        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
