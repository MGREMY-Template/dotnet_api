namespace Shared.Core.Queries.Auth.Auth;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;
using System.ComponentModel.DataAnnotations;

public class GetEmailConfirmationTokenQuery : IRequest<Result<GetEmailConfirmationTokenOutput>>
{
    [Required] [EmailAddress] public string Email { get; set; }
}
