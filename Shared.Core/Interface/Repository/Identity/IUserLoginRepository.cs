using Shared.Core.Entities.Identity;
using Shared.Domain.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository.Identity
{
	public interface IUserLoginRepository
	{
		public IEnumerable<UserLogin> GetAll();
		public Task<IEnumerable<UserLogin>> GetAllAsync(CancellationToken cancellationToken);
		public IEnumerable<UserLogin> List(IPaging paging);
		public Task<IEnumerable<UserLogin>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public UserLogin Find(object[] ids);
		public Task<UserLogin> FindAsync(object[] ids, CancellationToken cancellationToken);
		public UserLogin GetById(string loginProvider, string providerKey);
		public Task<UserLogin> GetByIdAsync(string loginProvider, string providerKey, CancellationToken cancellationToken);
	}
}
