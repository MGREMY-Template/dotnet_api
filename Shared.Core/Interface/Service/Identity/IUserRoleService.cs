using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserRoleController;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service.Identity
{
	public interface IUserRoleService
	{
		public Task<Result<UserRoleGetAllOutput>> GetAllAsync(CancellationToken cancellationToken);
		public Task<Result<UserRoleGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<Result<UserRoleGetByIdOutput>> GetByIdAsync(UserRoleGetByIdInput input, CancellationToken cancellationToken);
	}
}
