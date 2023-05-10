namespace API.Controllers.Identity;

using Domain.Constants;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.RoleController;
using Domain.Paging;
using Domain.Queries.Identity.Role;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

[Route("api/Identity/[controller]")]
public class RoleController : GenericController
{
    public RoleController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetAll)), Authorize(ClaimDefinition.IDENTITY_ROLE_GETALL)]
    [ProducesResponseType(typeof(Result<RoleDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<RoleDto[]> result = await this._mediator.Send(new GetRoleAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList)), Authorize(ClaimDefinition.IDENTITY_ROLE_GETLIST)]
    [ProducesResponseType(typeof(Result<RoleDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<RoleDto[]> result = await this._mediator.Send(new GetRoleListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById)), Authorize(ClaimDefinition.IDENTITY_ROLE_GETBYID)]
    [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromQuery] GetRoleByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<RoleDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
