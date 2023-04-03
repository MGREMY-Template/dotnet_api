namespace API.Controllers.Identity;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserController;
using Domain.Paging;
using Domain.Queries.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Queries.Identity.User;
using System.Threading;
using System.Threading.Tasks;

[Route("api/Identity/[controller]")]
public class UserController : GenericController
{
    private readonly IMediator _mediator;

    public UserController(
        IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet(nameof(GetAll))]
    [ProducesResponseType(typeof(Result<UserDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<UserDto[]> result = await this._mediator.Send(new GetUserAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList))]
    [ProducesResponseType(typeof(Result<UserDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<UserDto[]> result = await this._mediator.Send(new GetUserListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById))]
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
