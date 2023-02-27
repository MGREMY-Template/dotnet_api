using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserTokenController;
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
	public class UserTokenService : IUserTokenService
	{
		private readonly IUserTokenRepository _repository;
		private readonly ILogger _logger;
		private readonly IStringLocalizer _stringLocalizer;
		private readonly IStringLocalizer _globalStringLocalizer;

		public UserTokenService(
			IUserTokenRepository repository,
			ILogger<UserTokenService> logger,
			IStringLocalizer<Core.Resources.Services.Identity.UserTokenService> stringLocalizer,
			IStringLocalizer<Core.Resources.Global> globalStringLocalizer)
		{
			_repository = repository;
			_logger = logger;
			_stringLocalizer = stringLocalizer;
			_globalStringLocalizer = globalStringLocalizer;
		}

		public async Task<Result<UserTokenGetAllOutput>> GetAllAsync(CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetAllAsync(cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new UserTokenGetAllOutput(x.ToDto()));
		}

		public async Task<Result<UserTokenGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			paging.OrderBy ??= "Id";

			return Result.Create(await _repository.ListAsync(paging, cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new UserTokenGetListOutput(x.ToDto()));
		}

		public async Task<Result<UserTokenGetByIdOutput>> GetByIdAsync(UserTokenGetByIdInput input, CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetByIdAsync(input.UserId, input.LoginProvider, input.Name, cancellationToken))
				.Ensure(x => x is not null,
					_stringLocalizer.GetString(UserTokenServiceConstants.UserTokenFindNotFound).ToStringArray())
				.Map(x => new UserTokenGetByIdOutput(x.ToDto()));
		}
	}
}
