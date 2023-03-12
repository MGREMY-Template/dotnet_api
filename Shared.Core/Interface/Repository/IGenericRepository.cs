using Shared.Core.Entities;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository
{
	public interface IGenericRepository<T, TKey> : IDisposable
		where T : class, IBaseEntity<TKey>
		where TKey : IEquatable<TKey>
	{
		public IEnumerable<T> GetAll();
		public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
		public IEnumerable<T> List(IPaging paging);
		public Task<IEnumerable<T>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public int Count();
		public Task<int> CountAsync(CancellationToken cancellationToken);
		public void Add(T entity);
		public Task AddAsync(T entity, CancellationToken cancellationToken);
		public void Update(T entity);
		public void Delete(T entity);
		public T GetByKey(TKey id);
		public Task<T> GetByKeyAsync(TKey id, CancellationToken cancellationToken);
		public bool Exists(TKey id);
		public Task<bool> ExistsAsync(TKey id, CancellationToken cancellationToken);
	}
}
