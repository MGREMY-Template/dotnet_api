namespace API.Controllers.Identity;

using Domain.Constants;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserClaimController;
using Domain.DataTransferObject.Identity.UserController;
using Domain.Paging;
using Domain.Queries.Identity.UserClaim;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

[Route("api/Identity[controller]"), Authorize(Roles = RoleDefinition.ADMIN)]
public class UserClaimController : GenericController
{
    public UserClaimController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetAll)), Authorize(ClaimDefinition.IDENTITY_USERCLAIM_GETALL)]
    [ProducesResponseType(typeof(Result<UserClaimDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<UserClaimDto[]> result = await this._mediator.Send(new GetUserClaimAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList)), Authorize(ClaimDefinition.IDENTITY_USERCLAIM_GETLIST)]
    [ProducesResponseType(typeof(Result<UserClaimDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<UserClaimDto[]> result = await this._mediator.Send(new GetUserClaimListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById)), Authorize(ClaimDefinition.IDENTITY_USERCLAIM_GETBYID)]
    [ProducesResponseType(typeof(Result<UserClaimDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<UserClaimDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromQuery] GetUserClaimByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<UserClaimDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
