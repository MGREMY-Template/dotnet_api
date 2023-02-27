using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserRoleController;
using Shared.Core.Interface.Service.Identity;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Identity
{
	[Route("api/Identity/[controller]")]
	public class UserRoleController : GenericController
	{
		private readonly IUserRoleService _userRoleService;

		public UserRoleController(IUserRoleService roleClaimService)
		{
			_userRoleService = roleClaimService;
		}

		[HttpGet(nameof(GetAll))]
		[ProducesResponseType(typeof(Result<UserRoleGetAllOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserRoleGetAllOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetAll(
			CancellationToken cancellationToken = default)
		{
			var result = await _userRoleService.GetAllAsync(cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetList))]
		[ProducesResponseType(typeof(Result<UserRoleGetListOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserRoleGetListOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetList(
			[FromQuery] BasePaging paging,
			CancellationToken cancellationToken = default)
		{
			var result = await _userRoleService.GetListAsync(paging, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetById))]
		[ProducesResponseType(typeof(Result<UserRoleGetByIdOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<UserRoleGetByIdOutput>), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(
			[FromQuery] UserRoleGetByIdInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _userRoleService.GetByIdAsync(input, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}
	}
}
