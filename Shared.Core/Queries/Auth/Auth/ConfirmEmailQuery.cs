namespace Shared.Core.Queries.Auth.Auth;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using System.ComponentModel.DataAnnotations;

public class ConfirmEmailQuery : IRequest<Result<UserDto>>
{
    [Required] public string Email { get; set; }
    [Required] public string Token { get; set; }
}
