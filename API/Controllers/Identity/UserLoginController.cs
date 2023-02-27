using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserLoginController;
using Shared.Core.Interface.Service.Identity;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Identity
{
	[Route("api/Identity/[controller]")]
	public class UserLoginController : GenericController
	{
		private readonly IUserLoginService _userLoginService;

		public UserLoginController(IUserLoginService roleClaimService)
		{
			_userLoginService = roleClaimService;
		}

		[HttpGet(nameof(GetAll))]
		[ProducesResponseType(typeof(Result<UserLoginGetAllOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserLoginGetAllOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetAll(
			CancellationToken cancellationToken = default)
		{
			var result = await _userLoginService.GetAllAsync(cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetList))]
		[ProducesResponseType(typeof(Result<UserLoginGetListOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserLoginGetListOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetList(
			[FromQuery] BasePaging paging,
			CancellationToken cancellationToken = default)
		{
			var result = await _userLoginService.GetListAsync(paging, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetById))]
		[ProducesResponseType(typeof(Result<UserLoginGetByIdOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserLoginGetByIdOutput>), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(
			[FromQuery] UserLoginGetByIdInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _userLoginService.GetByIdAsync(input, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}
	}
}
