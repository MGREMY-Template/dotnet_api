using Shared.Core.Entities;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service
{
	public interface IGenericService<T, TKey>
		where T : IBaseEntity<TKey>
		where TKey : IEquatable<TKey>
	{
		public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
		public Task<IEnumerable<T>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<int> CountAsync(CancellationToken cancellationToken);
		public Task AddAsync(T entity, CancellationToken cancellationToken);
		public void Update(T entity);
		public void Delete(T entity);
		public Task<T> GetByKeyAsync(TKey id, CancellationToken cancellationToken);
		public Task<bool> ExistsAsync(TKey id, CancellationToken cancellationToken);
	}
}
