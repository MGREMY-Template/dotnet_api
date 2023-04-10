namespace API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class Health : GenericController
{
    public Health(
        IMediator mediator) : base(mediator)
    {

    }

    [HttpGet("Ping")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Ping(CancellationToken cancellationToken = default)
    {
        return this.Ok();
    }
}
