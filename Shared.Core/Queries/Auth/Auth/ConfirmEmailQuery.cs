namespace Shared.Core.Queries.Auth.Auth;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;
using System.ComponentModel.DataAnnotations;

public class ConfirmEmailQuery : IRequest<Result<ConfirmEmailOutput>>
{
    [Required] public string Email { get; set; }
    [Required] public string Token { get; set; }
}
