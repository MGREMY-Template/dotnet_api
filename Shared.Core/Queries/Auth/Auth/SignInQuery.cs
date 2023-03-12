using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Input;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;

namespace Shared.Core.Queries.Auth.Auth
{
    public class SignInQuery : IRequest<Result<SignInOutput>>
    {
        public SignInInput Input { get; set; }

        public SignInQuery(SignInInput input)
        {
            Input = input;
        }
    }
}
