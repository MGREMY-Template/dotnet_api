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
	public class RoleClaimRepository : IRoleClaimRepository
	{
		protected readonly IdentityContext _storeContext;

		public RoleClaimRepository(IdentityContext storeContext)
		{
			_storeContext = storeContext;
		}

		public IEnumerable<RoleClaim> GetAll()
		{
			return _storeContext.RoleClaims.ToList();
		}

		public async Task<IEnumerable<RoleClaim>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _storeContext.RoleClaims.ToListAsync(cancellationToken);
		}

		public IEnumerable<RoleClaim> List(IPaging paging)
		{
			return ApplySpecification(paging).ToList();
		}

		public async Task<IEnumerable<RoleClaim>> ListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			return await ApplySpecification(paging).ToListAsync(cancellationToken);
		}

		public RoleClaim Find(object[] ids)
		{
			return _storeContext.RoleClaims.Find(ids);
		}
		public async Task<RoleClaim> FindAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _storeContext.RoleClaims.FindAsync(ids, cancellationToken);
		}

		public RoleClaim GetById(int id)
		{
			return Find(new object[] { id });
		}

		public async Task<RoleClaim> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await FindAsync(new object[] { id }, cancellationToken);
		}

		protected virtual IQueryable<RoleClaim> ApplySpecification(IPaging paging)
		{
			if (string.IsNullOrEmpty(paging.OrderBy))
			{
				paging.OrderBy = "Id";
			}

			return _storeContext.RoleClaims.AsQueryable().ApplyPaging(paging);
		}
	}
}
