namespace Domain.Queries.Identity.RoleClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.RoleClaimController;
using MediatR;

public class GetRoleClaimAllQuery : IRequest<Result<RoleClaimDto[]>>
{
}
