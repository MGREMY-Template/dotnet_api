namespace Domain.Queries.Identity.RoleClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserClaimController;
using MediatR;

public class GetRoleClaimAllQuery : IRequest<Result<UserClaimDto[]>>
{
}
