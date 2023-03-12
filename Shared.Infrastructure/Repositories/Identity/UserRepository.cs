using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities.Identity;
using Shared.Core.Interface.Repository.Identity;
using Shared.Domain.Specification;
using Shared.Infrastructure.Data;
using Shared.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Repositories.Identity
{
	public class UserRepository : IUserRepository
	{
		protected readonly IdentityContext _storeContext;

		public UserRepository(IdentityContext storeContext)
		{
			_storeContext = storeContext;
		}

		public IEnumerable<User> GetAll()
		{
			return _storeContext.Users.ToList();
		}

		public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _storeContext.Users.ToListAsync(cancellationToken);
		}

		public IEnumerable<User> List(IPaging paging)
		{
			return ApplySpecification(paging).ToList();
		}

		public async Task<IEnumerable<User>> ListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			return await ApplySpecification(paging).ToListAsync(cancellationToken);
		}

		public User Find(object[] ids)
		{
			return _storeContext.Users.Find(ids);
		}
		public async Task<User> FindAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _storeContext.Users.FindAsync(ids, cancellationToken);
		}

		public User GetById(Guid id)
		{
			return Find(new object[] { id });
		}

		public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			return await FindAsync(new object[] { id }, cancellationToken);
		}

		protected virtual IQueryable<User> ApplySpecification(IPaging paging)
		{
			if (string.IsNullOrEmpty(paging.OrderBy))
			{
				paging.OrderBy = "Id";
			}

			return _storeContext.Users.AsQueryable().ApplyPaging(paging);
		}
	}
}
