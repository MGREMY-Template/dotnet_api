using Shared.Core.Entities.Identity;
using Shared.Domain.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository.Identity
{
	public interface IUserRoleRepository
	{
		public IEnumerable<UserRole> GetAll();
		public Task<IEnumerable<UserRole>> GetAllAsync(CancellationToken cancellationToken);
		public IEnumerable<UserRole> List(IPaging paging);
		public Task<IEnumerable<UserRole>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public UserRole Find(object[] ids);
		public Task<UserRole> FindAsync(object[] ids, CancellationToken cancellationToken);
		public UserRole GetById(int userId, int roleId);
		public Task<UserRole> GetByIdAsync(int userId, int roleId, CancellationToken cancellationToken);
	}
}
