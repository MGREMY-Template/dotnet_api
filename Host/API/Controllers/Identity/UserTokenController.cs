namespace API.Controllers.Identity;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Domain.DataTransferObject.Identity.UserTokenController;
using Domain.DataTransferObject;
using Domain.Queries.Identity.UserToken;
using Domain.Paging;

[Route("api/Identity/[controller]")]
public class UserTokenController : GenericController
{
    public UserTokenController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetAll))]
    [ProducesResponseType(typeof(Result<UserTokenDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<UserTokenDto[]> result = await this._mediator.Send(new GetUserTokenAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList))]
    [ProducesResponseType(typeof(Result<UserTokenDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<UserTokenDto[]> result = await this._mediator.Send(new GetUserTokenListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById))]
    [ProducesResponseType(typeof(Result<UserTokenDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<UserTokenDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromQuery] GetUserTokenByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<UserTokenDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
