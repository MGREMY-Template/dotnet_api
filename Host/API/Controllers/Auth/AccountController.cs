namespace API.Controllers.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AccountController.Output;
using Domain.Queries.Auth.Account;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

[Route("api/[controller]")]
public class AccountController : GenericController
{
    public AccountController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetRoles))]
    [ProducesResponseType(typeof(Result<GetRolesOutput>), StatusCodes.Status201Created)]
    public async Task<IActionResult> GetRoles(
        CancellationToken cancellationToken = default)
    {
        Result<GetRolesOutput> result = await this._mediator.Send(new GetRolesQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetClaims))]
    [ProducesResponseType(typeof(Result<GetClaimsOutput>), StatusCodes.Status201Created)]
    public async Task<IActionResult> GetClaims(
        CancellationToken cancellationToken = default)
    {
        Result<GetClaimsOutput> result = await this._mediator.Send(new GetClaimsQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
