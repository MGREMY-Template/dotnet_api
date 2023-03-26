namespace Shared.Core.Queries.Auth.Auth;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;
using System.ComponentModel.DataAnnotations;

public class SignInQuery : IRequest<Result<SignInOutput>>
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
