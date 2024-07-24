using Ecommerce.Application.Bases.Interfaces.Repositories;
using Ecommerce.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistance.Implementations.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private DbContext _dbContext;

        public WriteRepository(DbContext dbContext) => _dbContext = dbContext;
        private DbSet<T> _table => _dbContext.Set<T>();
        public async Task AddRangeAsync(IList<T> entities) => await _table.AddRangeAsync(entities);
        public async Task HardDeleteAsync(T entity) => await Task.Run(() => _table.Remove(entity));
        public async Task HardDeleteRangeAsync(IList<T> entities) => await Task.Run(() => _table.RemoveRange(entities));
        //public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();

        public async Task<T> UpdateAsync(T entity)
        {
            _table.Update(entity);
            return entity;
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task SoftDeleteAsync(T entity)
        {
            await Task.Run(() => _table.Update(entity));
        }
    }
}
