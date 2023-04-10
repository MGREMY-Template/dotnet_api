namespace API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

[ApiController]
[Authorize]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class GenericController : ControllerBase
{
    protected readonly IMediator _mediator;

    protected GenericController(
        IMediator mediator)
    {
        this._mediator = mediator;
    }
}
