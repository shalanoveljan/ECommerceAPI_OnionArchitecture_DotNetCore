using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Bases.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        /// <summary>
        /// Adds a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task AddAsync(T entity);

        /// <summary>
        /// Adds a range of entities asynchronously.
        /// </summary>
        /// <param name="entities">The list of entities to be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task AddRangeAsync(IList<T> entities);

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task that represents the asynchronous operation, containing the updated entity.</returns>
        public Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Performs a hard delete on an entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be hard deleted.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task HardDeleteAsync(T entity);

        /// <summary>
        /// Performs a hard delete on a range of entities asynchronously.
        /// </summary>
        /// <param name="entities">The list of entities to be hard deleted.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task HardDeleteRangeAsync(IList<T> entities);
        //public Task<int> SaveAsync();
    }
}
