using Shared.Core.Entities.Identity;
using Shared.Domain.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository.Identity
{
	public interface IUserTokenRepository
	{
		public IEnumerable<UserToken> GetAll();
		public Task<IEnumerable<UserToken>> GetAllAsync(CancellationToken cancellationToken);
		public IEnumerable<UserToken> List(IPaging paging);
		public Task<IEnumerable<UserToken>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public UserToken Find(object[] ids);
		public Task<UserToken> FindAsync(object[] ids, CancellationToken cancellationToken);
		public UserToken GetById(int userId, string loginProvider, string name);
		public Task<UserToken> GetByIdAsync(int userId, string loginProvider, string name, CancellationToken cancellationToken);
	}
}
