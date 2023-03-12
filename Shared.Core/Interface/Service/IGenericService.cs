using Shared.Core.DataTransferObject;
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
		public Task<Result<IEnumerable<T>>> GetAllAsync(CancellationToken cancellationToken);
		public Task<Result<IEnumerable<T>>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<Result<int>> CountAsync(CancellationToken cancellationToken);
		public Task<Result> AddAsync(T entity, CancellationToken cancellationToken);
		public Result Update(T entity);
		public Result Delete(T entity);
		public Task<Result<T>> GetByKeyAsync(TKey id, CancellationToken cancellationToken);
		public Task<Result<bool>> ExistsAsync(TKey id, CancellationToken cancellationToken);
	}
}
