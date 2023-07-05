namespace Domain.Queries.Auth.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class ConfirmEmailQuery : IRequest<Result<UserDto>>
{
    public string Email { get; set; }
    public string Token { get; set; }
}
