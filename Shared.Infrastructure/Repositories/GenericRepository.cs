using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities;
using Shared.Core.Interface.Repository;
using Shared.Domain.Specification;
using Shared.Infrastructure.Data;
using Shared.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Repositories
{
    public abstract class GenericRepository<T, TKey> : IGenericRepository<T, TKey>
        where T : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected readonly IdentityContext _storeContext;

        public GenericRepository(IdentityContext storeContext)
        {
            _storeContext = storeContext;
        }

        #region Func GetAll
        public IEnumerable<T> GetAll()
        {
            return _storeContext.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _storeContext.Set<T>().ToListAsync(cancellationToken);
        }
        #endregion
        #region Func List
        public IEnumerable<T> List(IPaging paging)
        {
            return ApplySpecification(paging).ToList();
        }
        public async Task<IEnumerable<T>> ListAsync(IPaging paging, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(paging).ToListAsync(cancellationToken);
        }
        #endregion
        #region Func Count
        public int Count()
        {
            return _storeContext.Set<T>().Count();
        }
        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _storeContext.Set<T>().CountAsync(cancellationToken);
        }
        #endregion
        #region Func Add
        public void Add(T entity)
        {
            _storeContext.Add(entity);
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _storeContext.AddAsync(entity, cancellationToken);
        }
        #endregion
        #region Func Update
        public void Update(T entity)
        {
            _storeContext.Update(entity);
        }
        #endregion
        #region Func Delete
        public void Delete(T entity)
        {
            _storeContext.Remove(entity);
        }
        #endregion
        #region Func GetByKey
        public T GetByKey(TKey id)
        {
            return _storeContext.Set<T>().FirstOrDefault(x => x.Id.Equals(id));
        }
        public async Task<T> GetByKeyAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await _storeContext.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }
        #endregion
        #region Func Exists
        public bool Exists(TKey id)
        {
            return _storeContext.Set<T>().Any(x => x.Id.Equals(id));
        }
        public async Task<bool> ExistsAsync(TKey id, CancellationToken cancellationToken)
        {
            return await _storeContext.Set<T>().AnyAsync(x => x.Id.Equals(id), cancellationToken);
        }
        #endregion

        protected virtual IQueryable<T> ApplySpecification(IPaging paging)
        {
            if (string.IsNullOrEmpty(paging.OrderBy))
            {
                paging.OrderBy = "Id";
            }

            return _storeContext.Set<T>().AsQueryable().ApplyPaging(paging);
        }

        public async void Dispose()
        {
            await _storeContext.SaveChangesAsync();
            GC.SuppressFinalize(this);
        }
    }
}
