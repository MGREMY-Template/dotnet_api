using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Controllers
{
	[ApiController]
	[Authorize]
	[Produces(MediaTypeNames.Application.Json)]
	public class GenericController : ControllerBase
	{
	}
}
