using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserRoleController;
using Shared.Core.Extensions;
using Shared.Core.Extensions.Entities.Identity;
using Shared.Core.Interface.Repository.Identity;
using Shared.Core.Interface.Service.Identity;
using Shared.Core.Resources.Services.Identity;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Application.Services.Identity
{
	public class UserRoleService : IUserRoleService
	{
		private readonly IUserRoleRepository _repository;
		private readonly ILogger _logger;
		private readonly IStringLocalizer _stringLocalizer;
		private readonly IStringLocalizer _globalStringLocalizer;

		public UserRoleService(
			IUserRoleRepository repository,
			ILogger<UserRoleService> logger,
			IStringLocalizer<Core.Resources.Services.Identity.UserRoleService> stringLocalizer,
			IStringLocalizer<Core.Resources.Global> globalStringLocalizer)
		{
			_repository = repository;
			_logger = logger;
			_stringLocalizer = stringLocalizer;
			_globalStringLocalizer = globalStringLocalizer;
		}

		public async Task<Result<UserRoleGetAllOutput>> GetAllAsync(CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetAllAsync(cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new UserRoleGetAllOutput(x.ToDto()));
		}

		public async Task<Result<UserRoleGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			paging.OrderBy ??= "Id";

			return Result.Create(await _repository.ListAsync(paging, cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new UserRoleGetListOutput(x.ToDto()));
		}

		public async Task<Result<UserRoleGetByIdOutput>> GetByIdAsync(UserRoleGetByIdInput input, CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetByIdAsync(input.UserId, input.RoleId, cancellationToken))
				.Ensure(x => x is not null,
					_stringLocalizer.GetString(UserRoleServiceConstants.UserRoleFindNotFound).ToStringArray())
				.Map(x => new UserRoleGetByIdOutput(x.ToDto()));
		}
	}
}
