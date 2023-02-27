using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.RoleController;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service.Identity
{
	public interface IRoleService
	{
		public Task<Result<RoleGetAllOutput>> GetAllAsync(CancellationToken cancellationToken);
		public Task<Result<RoleGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<Result<RoleGetByIdOutput>> GetByIdAsync(RoleGetByIdInput input, CancellationToken cancellationToken);
	}
}
