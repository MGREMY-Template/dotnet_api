namespace Domain.Queries.Identity.UserClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserClaimController;
using MediatR;

public class GetUserClaimAllQuery : IRequest<Result<UserClaimDto[]>>
{
}
