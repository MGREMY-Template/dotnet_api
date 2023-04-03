namespace Domain.Queries.Auth.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AuthController.Output;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetEmailConfirmationTokenQuery : IRequest<Result<GetEmailConfirmationTokenOutput>>
{
    [Required][EmailAddress] public string Email { get; set; }
}
