namespace Domain.Queries.Auth.Auth;

using Domain.DataTransferObject;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class SignUpQuery : IRequest<Result<UserDto>>
{
    [Required][EmailAddress] public string Email { get; set; }
    [Required] public string UserName { get; set; }
    [Required] public string Password { get; set; }
}
