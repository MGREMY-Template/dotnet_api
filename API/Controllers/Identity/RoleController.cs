using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.RoleController;
using Shared.Core.Interface.Service.Identity;
using Shared.Domain.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Identity
{
	[Route("api/Identity/[controller]")]
	public class RoleController : GenericController
	{
		private readonly IRoleService _roleService;

		public RoleController(IRoleService roleService)
		{
			_roleService = roleService;
		}

		[HttpGet(nameof(GetAll))]
		[ProducesResponseType(typeof(Result<RoleGetAllOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<RoleGetAllOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetAll(
			CancellationToken cancellationToken = default)
		{
			var result = await _roleService.GetAllAsync(cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetList))]
		[ProducesResponseType(typeof(Result<RoleGetListOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<RoleGetListOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetList(
			[FromQuery] BasePaging paging,
			CancellationToken cancellationToken = default)
		{
			var result = await _roleService.GetListAsync(paging, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}

		[HttpGet(nameof(GetById))]
		[ProducesResponseType(typeof(Result<RoleGetByIdOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<RoleGetByIdOutput>), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(
			[FromQuery] RoleGetByIdInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _roleService.GetByIdAsync(input, cancellationToken);

			return result.IsSuccess ?
				Ok(result) :
				BadRequest(result);
		}
	}
}
