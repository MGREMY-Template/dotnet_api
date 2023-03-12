using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Controllers
{
	[ApiController]
	[Authorize]
	[Consumes(MediaTypeNames.Application.Json)]
	[Produces(MediaTypeNames.Application.Json)]
	public class GenericController : ControllerBase
	{
	}
}
