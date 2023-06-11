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

    [HttpGet(nameof(GetAll)), Authorize(ClaimDefinition.APPLICATION_APPFILE_GETALL)]
    [ProducesResponseType(typeof(Result<AppFileDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken = default)
    {
        Result<AppFileDto[]> result = await this._mediator.Send(new GetAppFileAllQuery(), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetList)), Authorize(ClaimDefinition.APPLICATION_APPFILE_GETLIST)]
    [ProducesResponseType(typeof(Result<AppFileDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(
        [FromQuery] BasePaging paging,
        CancellationToken cancellationToken = default)
    {
        Result<AppFileDto[]> result = await this._mediator.Send(new GetAppFileListQuery(paging), cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetById)), Authorize(ClaimDefinition.APPLICATION_APPFILE_GETBYID)]
    [ProducesResponseType(typeof(Result<AppFileDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromQuery] GetAppFileByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<AppFileDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetStream)), Authorize(ClaimDefinition.APPLICATION_APPFILE_GETSTREAM)]
    [ProducesResponseType(typeof(PhysicalFileResult), StatusCodes.Status200OK)]
    [Produces("multipart/form-data")]
    public async Task<IActionResult> GetStream(
        [FromQuery] GetAppFileStreamQuery query,
        CancellationToken cancellationToken = default)
    {
        PhysicalFileResult result = await this._mediator.Send(query, cancellationToken);
        return result;
    }

    [HttpPost(nameof(Post)), Authorize(ClaimDefinition.APPLICATION_APPFILE_POSTAPPFILE)]
    [ProducesResponseType(typeof(Result<AppFileDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<AppFileDto>), StatusCodes.Status400BadRequest)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Post(
        [FromForm] PostAppFileQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<AppFileDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
