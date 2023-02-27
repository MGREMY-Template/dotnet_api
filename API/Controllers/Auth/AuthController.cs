using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController;
using Shared.Core.Interface.Service.Auth;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Auth
{
	[AllowAnonymous]
	[Route("api/Auth/[controller]")]
	public class AuthController : GenericController
	{
		private readonly IAuthService _authService;

		public AuthController(
			IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost(nameof(SignUp))]
		[ProducesResponseType(typeof(Result<SignUpOutput>), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(Result<SignUpOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> SignUp(
			[FromBody] SignUpInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _authService.SignUpAsync(input, cancellationToken);

			return result.IsSuccess ?
				StatusCode(201, result) :
				StatusCode(400, result);
		}

		[HttpGet(nameof(GetEmailConfimationToken))]
		[ProducesResponseType(typeof(Result<GetEmailConfirmationTokenOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<GetEmailConfirmationTokenOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetEmailConfimationToken(
			[FromQuery] GetEmailConfirmationInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _authService.GetEmailConfirmTokenAsync(input, cancellationToken);

			return result.IsSuccess ?
				StatusCode(200, result) :
				StatusCode(400, result);
		}

		[HttpPost(nameof(ConfirmEmail))]
		[ProducesResponseType(typeof(Result<ConfirmEmailOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<ConfirmEmailOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> ConfirmEmail(
			[FromQuery] ConfirmEmailInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _authService.ConfirmEmailAsync(input, cancellationToken);

			return result.IsSuccess ?
				StatusCode(200, result) :
				StatusCode(400, result);
		}

		[HttpPost(nameof(SignIn))]
		[ProducesResponseType(typeof(Result<SignInOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<SignInOutput>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> SignIn(
			[FromBody] SignInInput input,
			CancellationToken cancellationToken = default)
		{
			var result = await _authService.SignInAsync(input, cancellationToken);

			return result.IsSuccess ?
				StatusCode(200, result) :
				StatusCode(400, result);
		}
	}
}
