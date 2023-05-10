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
using Microsoft.AspNetCore.Authorization;
using Domain.Constants;

[Route("api/Identity/[controller]"), Authorize(Roles = RoleDefinition.ADMIN)]
public class UserRoleController : GenericController
{
    public UserRoleController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetAll)), Authorize(ClaimDefinition.IDENTITY_USERROLE_GETALL)]
    [ProducesResponseType(typeof(Result<UserRoleDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<UserRoleDto[]> result = await this._mediator.Send(new GetUserRoleAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList)), Authorize(ClaimDefinition.IDENTITY_USERROLE_GETLIST)]
    [ProducesResponseType(typeof(Result<UserRoleDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<UserRoleDto[]> result = await this._mediator.Send(new GetUserRoleListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById)), Authorize(ClaimDefinition.IDENTITY_USERROLE_GETBYID)]
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
