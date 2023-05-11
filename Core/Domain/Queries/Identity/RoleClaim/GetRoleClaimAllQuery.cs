namespace Domain.Queries.Identity.RoleClaim;

using Domain.DataTransferObject;
using MediatR;

public class GetRoleClaimAllQuery : IRequest<Result<RoleClaimDto[]>>
{
}
