using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserTokenController;
using Shared.Core.Interface.Service.Identity;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Identity
{
	[Route("api/Identity/[controller]")]
	public class UserTokenController : GenericController
	{
		private readonly IUserTokenService _userTokenService;

		public UserTokenController(IUserTokenService roleClaimService)
		{
			_userTokenService = roleClaimService;
		}

		[HttpGet(nameof(GetAll))]
		[ProducesResponseType(typeof(Result<UserTokenGetAllOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserTokenGetAllOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetAll(
			CancellationToken cancellationToken = default)
		{
			var result = await _userTokenService.GetAllAsync(cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetList))]
		[ProducesResponseType(typeof(Result<UserTokenGetListOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserTokenGetListOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetList(
			[FromQuery] BasePaging paging,
			CancellationToken cancellationToken = default)
		{
			var result = await _userTokenService.GetListAsync(paging, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetById))]
		[ProducesResponseType(typeof(Result<UserTokenGetByIdOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserTokenGetByIdOutput>), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(
			[FromQuery] UserTokenGetByIdInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _userTokenService.GetByIdAsync(input, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}
	}
}
