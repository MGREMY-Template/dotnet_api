namespace Shared.Core.Queries.Auth.Auth;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Input;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;

public class SignInQuery : IRequest<Result<SignInOutput>>
{
    public SignInInput Input { get; set; }

    public SignInQuery(SignInInput input)
    {
        this.Input = input;
    }
}
