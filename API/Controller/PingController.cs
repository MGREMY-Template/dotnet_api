using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class PingController : ControllerBase
{
    [HttpGet("Ping")]
    public IActionResult Ping(CancellationToken cancellationToken = default)
    {
        return Ok();
    }
}