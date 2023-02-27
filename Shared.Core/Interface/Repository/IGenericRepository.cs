using Shared.Core.Entities;
using Shared.Domain.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		public IEnumerable<T> GetAll();
		public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
		public IEnumerable<T> List(IPaging paging);
		public Task<IEnumerable<T>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public int Count();
		public Task<int> CountAsync(CancellationToken cancellationToken);
		public T Add(T entity);
		public Task<T> AddAsync(T entity, CancellationToken cancellationToken);
		public T Update(T entity);
		public T Delete(T entity);
		public T Find(object[] ids);
		public Task<T> FindAsync(object[] ids, CancellationToken cancellationToken);
		public T GetById(int id);
		public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
		public bool Exists(int id);
		public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
		public bool Exists(object[] ids);
		public Task<bool> ExistsAsync(object[] ids, CancellationToken cancellationToken);
	}
}
