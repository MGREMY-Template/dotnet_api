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
	public class UserTokenRepository : IUserTokenRepository
	{
		protected readonly IdentityContext _storeContext;

		public UserTokenRepository(IdentityContext storeContext)
		{
			_storeContext = storeContext;
		}

		public IEnumerable<UserToken> GetAll()
		{
			return _storeContext.UserTokens.ToList();
		}

		public async Task<IEnumerable<UserToken>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _storeContext.UserTokens.ToListAsync(cancellationToken);
		}

		public IEnumerable<UserToken> List(IPaging paging)
		{
			return ApplySpecification(paging).ToList();
		}

		public async Task<IEnumerable<UserToken>> ListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			return await ApplySpecification(paging).ToListAsync(cancellationToken);
		}

		public UserToken Find(object[] ids)
		{
			return _storeContext.UserTokens.Find(ids);
		}
		public async Task<UserToken> FindAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _storeContext.UserTokens.FindAsync(ids, cancellationToken);
		}

		public UserToken GetById(Guid userId, string loginProvider, string name)
		{
			return Find(new object[] { userId, loginProvider, name });
		}

		public async Task<UserToken> GetByIdAsync(Guid userId, string loginProvider, string name, CancellationToken cancellationToken)
		{
			return await FindAsync(new object[] { userId, loginProvider, name }, cancellationToken);
		}

		protected virtual IQueryable<UserToken> ApplySpecification(IPaging paging)
		{
			if (string.IsNullOrEmpty(paging.OrderBy))
			{
				paging.OrderBy = "UserId";
			}

			return _storeContext.UserTokens.AsQueryable().ApplyPaging(paging);
		}
	}
}
