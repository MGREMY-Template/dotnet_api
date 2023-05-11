namespace Domain.Queries.Identity.UserClaim;

using Domain.DataTransferObject;
using MediatR;

public class GetUserClaimAllQuery : IRequest<Result<UserClaimDto[]>>
{
}
