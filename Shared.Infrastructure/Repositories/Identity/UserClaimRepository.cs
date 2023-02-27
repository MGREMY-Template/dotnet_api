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
	public class UserClaimRepository : IUserClaimRepository
	{
		protected readonly IdentityContext _storeContext;

		public UserClaimRepository(IdentityContext storeContext)
		{
			_storeContext = storeContext;
		}

		public IEnumerable<UserClaim> GetAll()
		{
			return _storeContext.UserClaims.ToList();
		}

		public async Task<IEnumerable<UserClaim>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _storeContext.UserClaims.ToListAsync(cancellationToken);
		}

		public IEnumerable<UserClaim> List(IPaging paging)
		{
			return ApplySpecification(paging).ToList();
		}

		public async Task<IEnumerable<UserClaim>> ListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			return await ApplySpecification(paging).ToListAsync(cancellationToken);
		}

		public UserClaim Find(object[] ids)
		{
			return _storeContext.UserClaims.Find(ids);
		}
		public async Task<UserClaim> FindAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _storeContext.UserClaims.FindAsync(ids, cancellationToken);
		}

		public UserClaim GetById(int id)
		{
			return Find(new object[] { id });
		}

		public async Task<UserClaim> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await FindAsync(new object[] { id }, cancellationToken);
		}

		protected virtual IQueryable<UserClaim> ApplySpecification(IPaging paging)
		{
			if (string.IsNullOrEmpty(paging.OrderBy))
			{
				paging.OrderBy = "Id";
			}

			return _storeContext.UserClaims.AsQueryable().ApplyPaging(paging);
		}
	}
}
