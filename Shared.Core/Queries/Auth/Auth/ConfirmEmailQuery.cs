using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController;

namespace Shared.Core.Queries.Auth.Auth
{
    public class ConfirmEmailQuery : IRequest<Result<ConfirmEmailOutput>>
    {
        public ConfirmEmailInput Input { get; set; }

        public ConfirmEmailQuery(ConfirmEmailInput input)
        {
            Input = input;
        }
    }
}
