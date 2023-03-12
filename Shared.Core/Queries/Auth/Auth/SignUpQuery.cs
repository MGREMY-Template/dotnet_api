using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Input;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;

namespace Shared.Core.Queries.Auth.Auth
{
    public class SignUpQuery : IRequest<Result<SignUpOutput>>
    {
        public SignUpInput Input { get; set; }

        public SignUpQuery(SignUpInput input)
        {
            Input = input;
        }
    }
}
