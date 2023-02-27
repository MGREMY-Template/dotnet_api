using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities;
using Shared.Core.Interface.Repository;
using Shared.Domain.Specification;
using Shared.Infrastructure.Data;
using Shared.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Repositories
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
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
		public T Add(T entity)
		{
			var output = _storeContext.Add(entity).Entity;
			_storeContext.SaveChanges();
			return output;
		}
		public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
		{
			var output = (await _storeContext.AddAsync(entity, cancellationToken)).Entity;
			await _storeContext.SaveChangesAsync(cancellationToken);
			return output;
		}
		#endregion
		#region Func Update
		public T Update(T entity)
		{
			var output = _storeContext.Update(entity).Entity;
			_storeContext.SaveChanges();
			return output;
		}
		#endregion
		#region Func Delete
		public T Delete(T entity)
		{
			var output = _storeContext.Remove(entity).Entity;
			_storeContext.SaveChanges();
			return output;
		}
		#endregion
		#region Func Find
		public T Find(object[] ids)
		{
			return _storeContext.Set<T>().Find(ids);
		}
		public async Task<T> FindAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			return await _storeContext.Set<T>().FindAsync(ids, cancellationToken);
		}
		#endregion
		#region Func GetById
		public T GetById(int id)
		{
			return Find(new object[] { id });
		}
		public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			return await FindAsync(new object[] { id }, cancellationToken);
		}
		#endregion
		#region Func Exists
		public bool Exists(int id)
		{
			return _storeContext.Set<T>().Any(x => x.Id == id);
		}
		public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
		{
			return await _storeContext.Set<T>().AnyAsync(x => x.Id == id);
		}
		public bool Exists(object[] ids)
		{
			return _storeContext.Set<T>().Find(ids) is not null;
		}
		public async Task<bool> ExistsAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _storeContext.Set<T>().FindAsync(ids, cancellationToken) is not null;
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
	}
}
