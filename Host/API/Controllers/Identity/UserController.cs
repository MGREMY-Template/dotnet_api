namespace API.Controllers.Identity;

using Domain.DataTransferObject;
using Domain.Paging;
using Domain.Queries.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Domain.Constants;

[Route("api/Identity/[controller]"), Authorize(Roles = RoleDefinition.ADMIN)]
public class UserController : GenericController
{
    public UserController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetAll)), Authorize(ClaimDefinition.IDENTITY_USER_GETALL)]
    [ProducesResponseType(typeof(Result<UserDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<UserDto[]> result = await this._mediator.Send(new GetUserAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList)), Authorize(ClaimDefinition.IDENTITY_USER_GETLIST)]
    [ProducesResponseType(typeof(Result<UserDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<UserDto[]> result = await this._mediator.Send(new GetUserListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById)), Authorize(ClaimDefinition.IDENTITY_USER_GETBYID)]
    [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromQuery] GetUserByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<UserDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
