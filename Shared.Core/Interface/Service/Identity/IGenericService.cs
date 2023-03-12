using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service.Identity
{
	public interface IGenericService
	{
		public Task<Result<UserGetAllOutput>> GetAllAsync(CancellationToken cancellationToken);
		public Task<Result<UserGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken);
		public Task<Result<UserGetByIdOutput>> GetByIdAsync(UserGetByIdInput input, CancellationToken cancellationToken);
	}
}
