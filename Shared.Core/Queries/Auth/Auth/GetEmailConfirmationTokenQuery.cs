namespace Shared.Core.Queries.Auth.Auth;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Input;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;

public class GetEmailConfirmationTokenQuery : IRequest<Result<GetEmailConfirmationTokenOutput>>
{
    public GetEmailConfirmationInput Input { get; set; }

    public GetEmailConfirmationTokenQuery(GetEmailConfirmationInput input)
    {
        this.Input = input;
    }
}
