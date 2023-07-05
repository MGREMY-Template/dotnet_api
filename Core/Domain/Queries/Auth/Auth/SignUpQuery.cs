namespace Domain.Queries.Auth.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class SignUpQuery : IRequest<Result<UserDto>>
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
