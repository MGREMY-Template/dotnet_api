using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace API.Controllers
{
	[ApiController]
	[AllowAnonymous]
	[Route("[controller]")]
	public class Health : GenericController
	{
		[HttpGet("Ping")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Ping(CancellationToken cancellationToken = default)
		{
			return Ok();
		}
	}
}
