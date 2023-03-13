namespace Shared.Core.Queries.Auth.Auth;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Input;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;

public class ConfirmEmailQuery : IRequest<Result<ConfirmEmailOutput>>
{
    public ConfirmEmailInput Input { get; set; }

    public ConfirmEmailQuery(ConfirmEmailInput input)
    {
        this.Input = input;
    }
}
