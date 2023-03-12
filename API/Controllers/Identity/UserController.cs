using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Entities.Identity;
using Shared.Core.Interface.Service;
using Shared.Domain.Specification;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Identity
{
    [Route("api/Identity/[controller]")]
    public class UserController : GenericController
    {
        private readonly IGenericService<User, Guid> _genericService;

        public UserController(IGenericService<User, Guid> genericRepository)
        {
            _genericService = genericRepository;
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(typeof(Result<UserGetAllOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserGetAllOutput>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken = default)
        {
            var result = await _genericService.GetAllAsync(cancellationToken);

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
            var result = await _genericService.ListAsync(paging, cancellationToken);

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
            var result = await _genericService.GetByKeyAsync(id, cancellationToken);

            return result.IsSuccess ?
                Ok(result) :
                BadRequest(result);
        }
    }
}
