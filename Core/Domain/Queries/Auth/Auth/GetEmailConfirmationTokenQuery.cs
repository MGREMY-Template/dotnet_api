namespace Domain.Queries.Auth.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AuthController.Output;
using MediatR;

public class GetEmailConfirmationTokenQuery : IRequest<Result<GetEmailConfirmationTokenOutput>>
{
    public string Email { get; set; }
}
