using Shared.Core.Entities.Identity;
using Shared.Domain.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository.Identity
{
	public interface IUserClaimRepository
	{
		public IEnumerable<UserClaim> GetAll();
		public Task<IEnumerable<UserClaim>> GetAllAsync(CancellationToken cancellationToken);
		public IEnumerable<UserClaim> List(IPaging paging);
		public Task<IEnumerable<UserClaim>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public UserClaim Find(object[] ids);
		public Task<UserClaim> FindAsync(object[] ids, CancellationToken cancellationToken);
		public UserClaim GetById(int id);
		public Task<UserClaim> GetByIdAsync(int id, CancellationToken cancellationToken);
	}
}
