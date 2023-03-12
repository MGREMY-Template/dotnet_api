using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Input;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;

namespace Shared.Core.Queries.Auth.Auth
{
    public class GetEmailConfirmationTokenQuery : IRequest<Result<GetEmailConfirmationTokenOutput>>
    {
        public GetEmailConfirmationInput Input { get; set; }

        public GetEmailConfirmationTokenQuery(GetEmailConfirmationInput input)
        {
            Input = input;
        }
    }
}
