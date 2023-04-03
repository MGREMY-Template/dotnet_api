namespace Domain.Queries.Auth.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AuthController.Output;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class SignInQuery : IRequest<Result<SignInOutput>>
{
    [Required][EmailAddress] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
