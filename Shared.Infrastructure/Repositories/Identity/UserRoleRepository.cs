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
	public class UserRoleRepository : IUserRoleRepository
	{
		protected readonly IdentityContext _storeContext;

		public UserRoleRepository(IdentityContext storeContext)
		{
			_storeContext = storeContext;
		}

		public IEnumerable<UserRole> GetAll()
		{
			return _storeContext.UserRoles.ToList();
		}

		public async Task<IEnumerable<UserRole>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _storeContext.UserRoles.ToListAsync(cancellationToken);
		}

		public IEnumerable<UserRole> List(IPaging paging)
		{
			return ApplySpecification(paging).ToList();
		}

		public async Task<IEnumerable<UserRole>> ListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			return await ApplySpecification(paging).ToListAsync(cancellationToken);
		}

		public UserRole Find(object[] ids)
		{
			return _storeContext.UserRoles.Find(ids);
		}
		public async Task<UserRole> FindAsync(object[] ids, CancellationToken cancellationToken)
		{
			return await _storeContext.UserRoles.FindAsync(ids, cancellationToken);
		}

		public UserRole GetById(int userId, int roleId)
		{
			return Find(new object[] { userId, roleId });
		}

		public async Task<UserRole> GetByIdAsync(int userId, int roleId, CancellationToken cancellationToken)
		{
			return await FindAsync(new object[] { userId, roleId }, cancellationToken);
		}

		protected virtual IQueryable<UserRole> ApplySpecification(IPaging paging)
		{
			if (string.IsNullOrEmpty(paging.OrderBy))
			{
				paging.OrderBy = "UserId";
			}

			return _storeContext.UserRoles.AsQueryable().ApplyPaging(paging);
		}
	}
}
