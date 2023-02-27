using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.RoleClaimController;
using Shared.Core.Interface.Service.Identity;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Identity
{
	[Route("api/Identity/[controller]")]
	public class RoleClaimController : GenericController
	{
		private readonly IRoleClaimService _roleClaimService;

		public RoleClaimController(IRoleClaimService roleClaimService)
		{
			_roleClaimService = roleClaimService;
		}

		[HttpGet(nameof(GetAll))]
		[ProducesResponseType(typeof(Result<RoleClaimGetAllOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<RoleClaimGetAllOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetAll(
			CancellationToken cancellationToken = default)
		{
			var result = await _roleClaimService.GetAllAsync(cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetList))]
		[ProducesResponseType(typeof(Result<RoleClaimGetListOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<RoleClaimGetListOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetList(
			[FromQuery] BasePaging paging,
			CancellationToken cancellationToken = default)
		{
			var result = await _roleClaimService.GetListAsync(paging, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetById))]
		[ProducesResponseType(typeof(Result<RoleClaimGetByIdOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<RoleClaimGetByIdOutput>), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(
			[FromQuery] RoleClaimGetByIdInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _roleClaimService.GetByIdAsync(input, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}
	}
}
