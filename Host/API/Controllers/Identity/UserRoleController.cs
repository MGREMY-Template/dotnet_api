namespace API.Controllers.Identity;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Domain.DataTransferObject.Identity.UserRoleController;
using Domain.DataTransferObject;
using Domain.Queries.Identity.UserRole;
using Domain.Paging;

[Route("api/Identity/[controller]")]
public class UserRoleController : GenericController
{
    public UserRoleController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetAll))]
    [ProducesResponseType(typeof(Result<UserRoleDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<UserRoleDto[]> result = await this._mediator.Send(new GetUserRoleAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList))]
    [ProducesResponseType(typeof(Result<UserRoleDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<UserRoleDto[]> result = await this._mediator.Send(new GetUserRoleListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById))]
    [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromQuery] GetUserRoleByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<UserRoleDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
