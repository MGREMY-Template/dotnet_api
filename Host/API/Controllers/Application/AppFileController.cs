namespace API.Controllers.Application;

using Domain.Constants;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Application;
using Domain.Paging;
using Domain.Queries.Applciation.AppFile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

[Route("api/Application/[controller]")]
public class AppFileController : GenericController
{
    public AppFileController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(nameof(GetAll)), Authorize(ClaimDefinition.IDENTITY_APPFILE_GETALL)]
    [ProducesResponseType(typeof(Result<AppFileDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<AppFileDto[]> result = await this._mediator.Send(new GetAppFileAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList)), Authorize(ClaimDefinition.IDENTITY_APPFILE_GETLIST)]
    [ProducesResponseType(typeof(Result<AppFileDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<AppFileDto[]> result = await this._mediator.Send(new GetAppFileListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById)), Authorize(ClaimDefinition.IDENTITY_APPFILE_GETBYID)]
    [ProducesResponseType(typeof(Result<AppFileDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromQuery] GetAppFileByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<AppFileDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
