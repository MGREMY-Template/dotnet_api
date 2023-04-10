namespace API.Controllers.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AuthController.Output;
using Domain.DataTransferObject.Identity.UserController;
using Domain.Queries.Auth.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

[AllowAnonymous]
[Route("api/Auth/[controller]")]
public class AuthController : GenericController
{
    public AuthController(
        IMediator mediator) : base(mediator)
    {
    }

    [HttpPost(nameof(SignUp))]
    [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp(
        [FromBody] SignUpQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<UserDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpGet(nameof(GetEmailConfimationToken))]
    [ProducesResponseType(typeof(Result<GetEmailConfirmationTokenOutput>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<GetEmailConfirmationTokenOutput>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result<GetEmailConfirmationTokenOutput>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEmailConfimationToken(
        [FromQuery] GetEmailConfirmationTokenQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<GetEmailConfirmationTokenOutput> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpPost(nameof(ConfirmEmail))]
    [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ConfirmEmail(
        [FromBody] ConfirmEmailQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<UserDto> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }

    [HttpPost(nameof(SignIn))]
    [ProducesResponseType(typeof(Result<SignInOutput>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<SignInOutput>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Result<SignInOutput>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignIn(
        [FromBody] SignInQuery query,
        CancellationToken cancellationToken = default)
    {
        Result<SignInOutput> result = await this._mediator.Send(query, cancellationToken);
        return this.StatusCode(result.StatusCode, result);
    }
}
