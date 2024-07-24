using Ecommerce.Application.Bases.Interfaces.Repositories;
using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Bases.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {

        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        public Task<int> SaveAsync();
        public int Save();
    }
}
