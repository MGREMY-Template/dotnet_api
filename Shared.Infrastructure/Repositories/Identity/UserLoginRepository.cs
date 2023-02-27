using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities.Identity;
using Shared.Core.Interface.Repository.Identity;
using Shared.Domain.Specification;
using Shared.Infrastructure.Data;
using Shared.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Repositories.Identity
{
	public class UserLoginRepository : IUserLoginRepository
	{
		protected readonly IdentityContext _storeContext;

		public UserLoginRepository(IdentityContext storeContext)
		{
			_storeContext = storeContext;
		}

		public IEnumerable<UserLogin> GetAll()
		{
			return _storeContext.UserLogins.ToList();
		}

		public async Task<IEnumerable<UserLogin>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _storeContext.UserLogins.ToListAsync(cancellationToken);
		}

		public IEnumerable<UserLogin> List(IPaging paging)
		{
			return ApplySpecification(paging).ToList();
		}

		public async Task<IEnumerable<UserLogin>> ListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			return await ApplySpecification(paging).ToListAsync(cancellationToken);
		}

		public UserLogin Find(object[] ids)
		{
			return _storeContext.UserLogins.Find(ids);
		}
		public async Task<UserLogin> FindAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _storeContext.UserLogins.FindAsync(ids, cancellationToken);
		}

		public UserLogin GetById(string loginProvider, string providerKey)
		{
			return Find(new object[] { loginProvider, providerKey });
		}

		public async Task<UserLogin> GetByIdAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
		{
			return await FindAsync(new object[] { loginProvider, providerKey }, cancellationToken);
		}

		protected virtual IQueryable<UserLogin> ApplySpecification(IPaging paging)
		{
			if (string.IsNullOrEmpty(paging.OrderBy))
			{
				paging.OrderBy = "LoginProvider";
			}

			return _storeContext.UserLogins.AsQueryable().ApplyPaging(paging);
		}
	}
}
