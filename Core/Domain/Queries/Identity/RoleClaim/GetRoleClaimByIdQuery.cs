namespace Domain.Queries.Identity.RoleClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class GetRoleClaimByIdQuery : IRequest<Result<RoleClaimDto>>
{
    public int Id { get; set; }
}
