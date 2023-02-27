using Shared.Core.Entities.Identity;
using Shared.Domain.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository.Identity
{
	public interface IRoleRepository
	{
		public IEnumerable<Role> GetAll();
		public Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken);
		public IEnumerable<Role> List(IPaging paging);
		public Task<IEnumerable<Role>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public Role Find(object[] ids);
		public Task<Role> FindAsync(object[] ids, CancellationToken cancellationToken);
		public Role GetById(int id);
		public Task<Role> GetByIdAsync(int id, CancellationToken cancellationToken);
	}
}
