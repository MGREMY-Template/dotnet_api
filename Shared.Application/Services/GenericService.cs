using Shared.Core.Entities;
using Shared.Core.Interface.Repository;
using Shared.Core.Interface.Service;
using Shared.Domain.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Application.Services
{
	public abstract class GenericService<T> : IGenericService<T> where T : BaseEntity
	{
		protected readonly IGenericRepository<T> _genericRepository;

		public GenericService(IGenericRepository<T> genericRepository)
		{
			_genericRepository = genericRepository;
		}

		public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _genericRepository.GetAllAsync(cancellationToken);
		}
		public async Task<IEnumerable<T>> ListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			return await _genericRepository.ListAsync(paging, cancellationToken);
		}
		public async Task<int> CountAsync(CancellationToken cancellationToken)
		{
			return await _genericRepository.CountAsync(cancellationToken);
		}
		public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
		{
			return await _genericRepository.AddAsync(entity, cancellationToken);
		}
		public T Update(T entity)
		{
			return _genericRepository.Update(entity);
		}
		public T Delete(T entity)
		{
			return _genericRepository.Delete(entity);
		}
		public async Task<T> FindAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _genericRepository.FindAsync(ids, cancellationToken);
		}
		public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await _genericRepository.GetByIdAsync(id, cancellationToken);
		}
		public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
		{
			return await _genericRepository.ExistsAsync(id, cancellationToken);
		}
		public async Task<bool> ExistsAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _genericRepository.ExistsAsync(ids, cancellationToken);
		}
	}
}
