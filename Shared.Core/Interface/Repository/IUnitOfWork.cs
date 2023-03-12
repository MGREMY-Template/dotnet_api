using Shared.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public int SaveChanges();
        public Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

    public interface IUnitOfWork<T, TKey> : IUnitOfWork
        where T : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public IGenericRepository<T, TKey> GenericRepository { get; }
    }
}
