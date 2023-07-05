namespace Domain.Queries.Auth.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AuthController.Output;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class SignInQuery : IRequest<Result<SignInOutput>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
