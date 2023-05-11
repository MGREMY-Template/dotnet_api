namespace Domain.Queries.Identity.UserLogin;

using Domain.DataTransferObject;
using MediatR;

public class GetUserLoginAllQuery : IRequest<Result<UserLoginDto[]>>
{
}
