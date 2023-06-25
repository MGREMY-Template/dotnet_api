namespace Domain.Queries.Identity.UserToken;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class GetUserTokenAllQuery : IRequest<Result<UserTokenDto[]>>
{
}
