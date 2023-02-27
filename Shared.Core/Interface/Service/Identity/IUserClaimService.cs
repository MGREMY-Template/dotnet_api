using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserClaimController;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service.Identity
{
	public interface IUserClaimService
	{
		public Task<Result<UserClaimGetAllOutput>> GetAllAsync(CancellationToken cancellationToken);
		public Task<Result<UserClaimGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<Result<UserClaimGetByIdOutput>> GetByIdAsync(UserClaimGetByIdInput input, CancellationToken cancellationToken);
	}
}
