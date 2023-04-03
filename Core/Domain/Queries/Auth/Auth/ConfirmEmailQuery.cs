namespace Domain.Queries.Auth.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserController;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class ConfirmEmailQuery : IRequest<Result<UserDto>>
{
    [Required][EmailAddress] public string Email { get; set; }
    [Required] public string Token { get; set; }
}
