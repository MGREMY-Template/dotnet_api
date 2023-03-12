using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController;

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
