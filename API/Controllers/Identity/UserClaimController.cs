using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserClaimController;
using Shared.Core.Interface.Service.Identity;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Identity
{
	[Route("api/Identity/[controller]")]
	public class UserClaimController : GenericController
	{
		private readonly IUserClaimService _userClaimService;

		public UserClaimController(IUserClaimService userClaimService)
		{
			_userClaimService = userClaimService;
		}

		[HttpGet(nameof(GetAll))]
		[ProducesResponseType(typeof(Result<UserClaimGetAllOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserClaimGetAllOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetAll(
			CancellationToken cancellationToken = default)
		{
			var result = await _userClaimService.GetAllAsync(cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetList))]
		[ProducesResponseType(typeof(Result<UserClaimGetListOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserClaimGetListOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetList(
			[FromQuery] BasePaging paging,
			CancellationToken cancellationToken = default)
		{
			var result = await _userClaimService.GetListAsync(paging, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetById))]
		[ProducesResponseType(typeof(Result<UserClaimGetByIdOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserClaimGetByIdOutput>), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(
			[FromQuery] UserClaimGetByIdInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _userClaimService.GetByIdAsync(input, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}
	}
}
