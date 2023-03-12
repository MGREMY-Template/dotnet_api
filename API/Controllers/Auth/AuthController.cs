using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Input;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;
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
        public async Task<IActionResult> SignUp(
            [FromBody] SignUpInput input,
            CancellationToken cancellationToken = default)
        {
            var query = new SignUpQuery(input);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet(nameof(GetEmailConfimationToken))]
        [ProducesResponseType(typeof(Result<GetEmailConfirmationTokenOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<GetEmailConfirmationTokenOutput>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEmailConfimationToken(
            [FromQuery] GetEmailConfirmationInput input,
            CancellationToken cancellationToken = default)
        {
            var query = new GetEmailConfirmationTokenQuery(input);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost(nameof(ConfirmEmail))]
        [ProducesResponseType(typeof(Result<ConfirmEmailOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<ConfirmEmailOutput>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmEmail(
            [FromQuery] ConfirmEmailInput input,
            CancellationToken cancellationToken = default)
        {
            var query = new ConfirmEmailQuery(input);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost(nameof(SignIn))]
        [ProducesResponseType(typeof(Result<SignInOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<SignInOutput>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn(
            [FromBody] SignInInput input,
            CancellationToken cancellationToken = default)
        {
            var query = new SignInQuery(input);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
