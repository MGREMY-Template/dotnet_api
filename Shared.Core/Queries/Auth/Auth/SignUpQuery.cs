namespace Shared.Core.Queries.Auth.Auth;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Input;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;

public class SignUpQuery : IRequest<Result<SignUpOutput>>
{
    public SignUpInput Input { get; set; }

    public SignUpQuery(SignUpInput input)
    {
        this.Input = input;
    }
}
