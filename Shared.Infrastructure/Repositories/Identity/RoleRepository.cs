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
	public class RoleRepository : IRoleRepository
	{
		protected readonly IdentityContext _storeContext;

		public RoleRepository(IdentityContext storeContext)
		{
			_storeContext = storeContext;
		}

		public IEnumerable<Role> GetAll()
		{
			return _storeContext.Roles.ToList();
		}

		public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _storeContext.Roles.ToListAsync(cancellationToken);
		}

		public IEnumerable<Role> List(IPaging paging)
		{
			return ApplySpecification(paging).ToList();
		}

		public async Task<IEnumerable<Role>> ListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			return await ApplySpecification(paging).ToListAsync(cancellationToken);
		}

		public Role Find(object[] ids)
		{
			return _storeContext.Roles.Find(ids);
		}
		public async Task<Role> FindAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _storeContext.Roles.FindAsync(ids, cancellationToken);
		}

		public Role GetById(int id)
		{
			return Find(new object[] { id });
		}

		public async Task<Role> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await FindAsync(new object[] { id }, cancellationToken);
		}

		protected virtual IQueryable<Role> ApplySpecification(IPaging paging)
		{
			if (string.IsNullOrEmpty(paging.OrderBy))
			{
				paging.OrderBy = "Id";
			}

			return _storeContext.Roles.AsQueryable().ApplyPaging(paging);
		}
	}
}
