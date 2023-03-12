using Shared.Core.Entities.Identity;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Repository.Identity
{
	public interface IUserRepository
	{
		public IEnumerable<User> GetAll();
		public Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
		public IEnumerable<User> List(IPaging paging);
		public Task<IEnumerable<User>> ListAsync(IPaging paging, CancellationToken cancellationToken);
		public User Find(object[] ids);
		public Task<User> FindAsync(object[] ids, CancellationToken cancellationToken);
		public User GetById(Guid id);
		public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	}
}
