namespace Domain.Queries.Identity.UserToken;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserTokenController;
using MediatR;

public class GetUserTokenAllQuery : IRequest<Result<UserTokenDto[]>>
{
}
