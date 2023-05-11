namespace Domain.Queries.Identity.UserToken;

using Domain.DataTransferObject;
using MediatR;

public class GetUserTokenAllQuery : IRequest<Result<UserTokenDto[]>>
{
}
