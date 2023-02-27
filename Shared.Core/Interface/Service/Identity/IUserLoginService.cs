using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserLoginController;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service.Identity
{
	public interface IUserLoginService
	{
		public Task<Result<UserLoginGetAllOutput>> GetAllAsync(CancellationToken cancellationToken);
		public Task<Result<UserLoginGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<Result<UserLoginGetByIdOutput>> GetByIdAsync(UserLoginGetByIdInput input, CancellationToken cancellationToken);
	}
}
