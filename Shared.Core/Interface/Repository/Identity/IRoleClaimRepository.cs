using Shared.Core.Entities.Identity;
using Shared.Domain.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository.Identity
{
	public interface IRoleClaimRepository
	{
		public IEnumerable<RoleClaim> GetAll();
		public Task<IEnumerable<RoleClaim>> GetAllAsync(CancellationToken cancellationToken);
		public IEnumerable<RoleClaim> List(IPaging paging);
		public Task<IEnumerable<RoleClaim>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public RoleClaim Find(object[] ids);
		public Task<RoleClaim> FindAsync(object[] ids, CancellationToken cancellationToken);
		public RoleClaim GetById(int id);
		public Task<RoleClaim> GetByIdAsync(int id, CancellationToken cancellationToken);
	}
}
