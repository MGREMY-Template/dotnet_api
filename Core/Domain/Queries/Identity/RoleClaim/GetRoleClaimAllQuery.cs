namespace Domain.Queries.Identity.RoleClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class GetRoleClaimAllQuery : IRequest<Result<RoleClaimDto[]>>
{
}
