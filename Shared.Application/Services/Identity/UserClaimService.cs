using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserClaimController;
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
	public class UserClaimService : IUserClaimService
	{
		private readonly IUserClaimRepository _repository;
		private readonly ILogger _logger;
		private readonly IStringLocalizer _stringLocalizer;
		private readonly IStringLocalizer _globalStringLocalizer;

		public UserClaimService(
			IUserClaimRepository repository,
			ILogger<UserClaimService> logger,
			IStringLocalizer<Core.Resources.Services.Identity.UserClaimService> stringLocalizer,
			IStringLocalizer<Core.Resources.Global> globalStringLocalizer)
		{
			_repository = repository;
			_logger = logger;
			_stringLocalizer = stringLocalizer;
			_globalStringLocalizer = globalStringLocalizer;
		}

		public async Task<Result<UserClaimGetAllOutput>> GetAllAsync(CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetAllAsync(cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new UserClaimGetAllOutput(x.ToDto()));
		}

		public async Task<Result<UserClaimGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			paging.OrderBy ??= "Id";

			return Result.Create(await _repository.ListAsync(paging, cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new UserClaimGetListOutput(x.ToDto()));
		}

		public async Task<Result<UserClaimGetByIdOutput>> GetByIdAsync(UserClaimGetByIdInput input, CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetByIdAsync(input.Id, cancellationToken))
				.Ensure(x => x is not null,
					_stringLocalizer.GetString(UserClaimServiceConstants.UserClaimFindNotFound).ToStringArray())
				.Map(x => new UserClaimGetByIdOutput(x.ToDto()));
		}
	}
}
