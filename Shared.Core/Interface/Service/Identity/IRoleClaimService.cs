using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.RoleClaimController;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service.Identity
{
	public interface IRoleClaimService
	{
		public Task<Result<RoleClaimGetAllOutput>> GetAllAsync(CancellationToken cancellationToken);
		public Task<Result<RoleClaimGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<Result<RoleClaimGetByIdOutput>> GetByIdAsync(RoleClaimGetByIdInput input, CancellationToken cancellationToken);
	}
}
