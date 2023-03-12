using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Interface.Service.Identity;
using Shared.Domain.Specification;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Identity
{
    [Route("api/Identity/[controller]")]
    public class UserController : GenericController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(typeof(Result<UserGetAllOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserGetAllOutput>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken = default)
        {
            var result = await _userService.GetAllAsync<UserDto>(cancellationToken);

            return result.IsSuccess ?
                Ok(result) :
                BadRequest(result);
        }

        [HttpGet(nameof(GetList))]
        [ProducesResponseType(typeof(Result<UserGetListOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserGetListOutput>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetList(
            [FromQuery] BasePaging paging,
            CancellationToken cancellationToken = default)
        {
            var result = await _userService.ListAsync<UserDto>(paging, cancellationToken);

            return result.IsSuccess ?
                Ok(result) :
                BadRequest(result);
        }

        [HttpGet(nameof(GetById))]
        [ProducesResponseType(typeof(Result<UserGetByIdOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserGetByIdOutput>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromQuery] Guid id,
            CancellationToken cancellationToken = default)
        {
            var result = await _userService.GetByKeyAsync<UserDto>(id, cancellationToken);

            return result.IsSuccess ?
                Ok(result) :
                BadRequest(result);
        }
    }
}
