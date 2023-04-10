namespace Domain.Queries.Identity.UserLogin;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserLoginController;
using MediatR;

public class GetUserLoginAllQuery : IRequest<Result<UserLoginDto[]>>
{
}
