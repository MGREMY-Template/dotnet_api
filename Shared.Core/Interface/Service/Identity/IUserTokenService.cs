using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserTokenController;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service.Identity
{
	public interface IUserTokenService
	{
		public Task<Result<UserTokenGetAllOutput>> GetAllAsync(CancellationToken cancellationToken);
		public Task<Result<UserTokenGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<Result<UserTokenGetByIdOutput>> GetByIdAsync(UserTokenGetByIdInput input, CancellationToken cancellationToken);
	}
}
