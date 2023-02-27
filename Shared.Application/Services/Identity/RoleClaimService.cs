using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.RoleClaimController;
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
	public class RoleClaimService : IRoleClaimService
	{
		private readonly IRoleClaimRepository _repository;
		private readonly ILogger _logger;
		private readonly IStringLocalizer _stringLocalizer;
		private readonly IStringLocalizer _globalStringLocalizer;

		public RoleClaimService(
			IRoleClaimRepository repository,
			ILogger<RoleClaimService> logger,
			IStringLocalizer<Core.Resources.Services.Identity.RoleClaimService> stringLocalizer,
			IStringLocalizer<Core.Resources.Global> globalStringLocalizer)
		{
			_repository = repository;
			_logger = logger;
			_stringLocalizer = stringLocalizer;
			_globalStringLocalizer = globalStringLocalizer;
		}

		public async Task<Result<RoleClaimGetAllOutput>> GetAllAsync(CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetAllAsync(cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new RoleClaimGetAllOutput(x.ToDto()));
		}

		public async Task<Result<RoleClaimGetListOutput>> GetListAsync(IPaging paging, CancellationToken cancellationToken)
		{
			paging.OrderBy ??= "Id";

			return Result.Create(await _repository.ListAsync(paging, cancellationToken))
				.Ensure(x => x is not null,
					_globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
				.Map(x => new RoleClaimGetListOutput(x.ToDto()));
		}

		public async Task<Result<RoleClaimGetByIdOutput>> GetByIdAsync(RoleClaimGetByIdInput input, CancellationToken cancellationToken)
		{
			return Result.Create(await _repository.GetByIdAsync(input.Id, cancellationToken))
				.Ensure(x => x is not null,
					_stringLocalizer.GetString(RoleClaimServiceContants.RoleClaimFindNotFound).ToStringArray())
				.Map(x => new RoleClaimGetByIdOutput(x.ToDto()));
		}
	}
}
