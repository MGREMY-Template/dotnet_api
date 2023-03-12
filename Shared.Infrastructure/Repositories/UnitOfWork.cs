using Shared.Core.Entities;
using Shared.Core.Interface.Repository;
using Shared.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityContext _identityContext;

        public UnitOfWork(
            IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        public async void Dispose()
        {
            await SaveChangesAsync();
            GC.SuppressFinalize(this);
        }

        public int SaveChanges() =>
            _identityContext.SaveChanges();

        public async Task<int> SaveChangesAsync() =>
            await _identityContext.SaveChangesAsync();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) =>
            await _identityContext.SaveChangesAsync(cancellationToken);
    }

    public class UnitOfWork<T, TKey> : IUnitOfWork<T, TKey>
        where T : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly IdentityContext _identityContext;
        public IGenericRepository<T, TKey> GenericRepository { get; }

        public UnitOfWork(
            IdentityContext identityContext,
            IGenericRepository<T, TKey> genericRepository)
        {
            _identityContext = identityContext;
            GenericRepository = genericRepository;
        }

        public async void Dispose()
        {
            await SaveChangesAsync();
            GC.SuppressFinalize(this);
        }

        public int SaveChanges() =>
            _identityContext.SaveChanges();

        public async Task<int> SaveChangesAsync() =>
            await _identityContext.SaveChangesAsync();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) =>
            await _identityContext.SaveChangesAsync(cancellationToken);
    }
}
