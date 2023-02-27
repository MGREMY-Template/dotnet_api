using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserLoginController;
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
	public class UserLoginService : IUserLoginService
	{
		private readonly IUserLoginRepository _repository;
		private readonly ILogger _logger;
		private readonly IStringLocalizer _stringLocalizer;
		private readonly IStringLocalizer _globalStringLocalizer;

		public UserLoginService(
			IUserLoginRepository repository,
			ILogger<UserLoginService> logger,
			IStringLocalizer<Core.Resources.Services.Identity.UserLoginService> stringLocalizer,
			IStringLocalizer<Core.Resources.Global> globalStringLocalizer)
		{
			_repository = repository;
			_logger = logger;
			_stringLocalizer = stringLocalizer;
			_globalStringLocalizer = globalStringLocalizer;
		}

		public async Task<Result<UserLoginGetAllOutput>> GetAllAsync(CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetAllAsync(cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new UserLoginGetAllOutput(x.ToDto()));
		}

		public async Task<Result<UserLoginGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			paging.OrderBy ??= "Id";

			return Result.Create(await _repository.ListAsync(paging, cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new UserLoginGetListOutput(x.ToDto()));
		}

		public async Task<Result<UserLoginGetByIdOutput>> GetByIdAsync(UserLoginGetByIdInput input, CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetByIdAsync(input.LoginProvider, input.ProviderKey, cancellationToken))
				.Ensure(x => x is not null,
					_stringLocalizer.GetString(UserLoginServiceConstants.UserLoginFindNotFound).ToStringArray())
				.Map(x => new UserLoginGetByIdOutput(x.ToDto()));
		}
	}
}
