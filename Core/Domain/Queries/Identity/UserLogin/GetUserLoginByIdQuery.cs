namespace Domain.Queries.Identity.UserLogin;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class GetUserLoginByIdQuery : IRequest<Result<UserLoginDto>>
{
    public string LoginProvider { get; set; }
    public string ProviderKey { get; set; }
}
