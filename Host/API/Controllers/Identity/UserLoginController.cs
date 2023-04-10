namespace API.Controllers.Identity;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserLoginController;
using Domain.Paging;
using Domain.Queries.Identity.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

[Route("api/Identity/[controller]")]
public class UserLoginController : GenericController
{
    public UserLoginController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetAll))]
    [ProducesResponseType(typeof(Result<UserLoginDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<UserLoginDto[]> result = await this._mediator.Send(new GetUserLoginAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList))]
    [ProducesResponseType(typeof(Result<UserLoginDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<UserLoginDto[]> result = await this._mediator.Send(new GetUserLoginListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById))]
    [ProducesResponseType(typeof(Result<UserLoginDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<UserLoginDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromQuery] GetUserLoginByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<UserLoginDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
