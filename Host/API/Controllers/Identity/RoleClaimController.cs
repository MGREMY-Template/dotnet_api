namespace API.Controllers.Identity;

using Domain.Constants;
using Domain.DataTransferObject;
using Domain.Paging;
using Domain.Queries.Identity.RoleClaim;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

[Route("api/Identity/[controller]"), Authorize(Roles = RoleDefinition.ADMIN)]
public class RoleClaimController : GenericController
{
    public RoleClaimController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetAll)), Authorize(ClaimDefinition.IDENTITY_ROLECLAIM_GETALL)]
    [ProducesResponseType(typeof(Result<RoleClaimDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<RoleClaimDto[]> result = await this._mediator.Send(new GetRoleClaimAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList)), Authorize(ClaimDefinition.IDENTITY_ROLECLAIM_GETLIST)]
    [ProducesResponseType(typeof(Result<RoleClaimDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<RoleClaimDto[]> result = await this._mediator.Send(new GetRoleClaimListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById)), Authorize(ClaimDefinition.IDENTITY_ROLECLAIM_GETBYID)]
    [ProducesResponseType(typeof(Result<RoleClaimDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<RoleClaimDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromQuery] GetRoleClaimByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<RoleClaimDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
