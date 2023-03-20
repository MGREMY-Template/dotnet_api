namespace API.Controllers.Identity;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Paging;
using Shared.Core.Queries.Identity.User;
using System;
using System.Collections.Generic;
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
    [ProducesResponseType(typeof(Result<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        var query = new GetUserAllQuery();
        Result<IEnumerable<UserDto>> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList))]
    [ProducesResponseType(typeof(Result<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        var query = new GetUserListQuery(paging);
        Result<IEnumerable<UserDto>> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById))]
    [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromQuery] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetUserByIdQuery(id);
        Result<UserDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
