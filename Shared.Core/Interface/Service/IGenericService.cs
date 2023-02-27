using Shared.Core.Entities;
using Shared.Domain.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service
{
	public interface IGenericService<T> where T : BaseEntity
	{
		public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
		public Task<IEnumerable<T>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<int> CountAsync(CancellationToken cancellationToken);
		public Task<T> AddAsync(T entity, CancellationToken cancellationToken);
		public T Update(T entity);
		public T Delete(T entity);
		public Task<T> FindAsync(object[] ids, CancellationToken cancellationToken);
		public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsAsync(object[] ids, CancellationToken cancellationToken);
	}
}
