using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController;
using Shared.Core.Queries.Auth.Auth;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers.Auth
{
	[AllowAnonymous]
	[Route("api/Auth/[controller]")]
	public class AuthController : GenericController
	{
		private readonly IMediator _mediator;

		public AuthController(
			IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost(nameof(SignUp))]
		[ProducesResponseType(typeof(Result<SignUpOutput>), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(Result<SignUpOutput>), StatusCodes.Status400BadRequest)]
		public async Task<Result<SignUpOutput>> SignUp(
			[FromBody] SignUpInput input,
			CancellationToken cancellationToken = default)
		{
			return await _mediator.Send(new SignUpQuery(input), cancellationToken);
		}

		[HttpGet(nameof(GetEmailConfimationToken))]
		[ProducesResponseType(typeof(Result<GetEmailConfirmationTokenOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<GetEmailConfirmationTokenOutput>), StatusCodes.Status400BadRequest)]
		public async Task<Result<GetEmailConfirmationTokenOutput>> GetEmailConfimationToken(
			[FromQuery] GetEmailConfirmationInput input,
			CancellationToken cancellationToken = default)
		{
			return await _mediator.Send(new GetEmailConfirmationTokenQuery(input), cancellationToken);
		}

		[HttpPost(nameof(ConfirmEmail))]
		[ProducesResponseType(typeof(Result<ConfirmEmailOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<ConfirmEmailOutput>), StatusCodes.Status400BadRequest)]
		public async Task<Result<ConfirmEmailOutput>> ConfirmEmail(
			[FromQuery] ConfirmEmailInput input,
			CancellationToken cancellationToken = default)
		{
			return await _mediator.Send(new ConfirmEmailQuery(input), cancellationToken);
		}

		[HttpPost(nameof(SignIn))]
		[ProducesResponseType(typeof(Result<SignInOutput>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Result<SignInOutput>), StatusCodes.Status400BadRequest)]
		public async Task<Result<SignInOutput>> SignIn(
			[FromBody] SignInInput input,
			CancellationToken cancellationToken = default)
		{
			return await _mediator.Send(new SignInQuery(input), cancellationToken);
		}
	}
}
