namespace Domain.Queries.Identity.RoleClaim;

using Domain.DataTransferObject;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetRoleClaimByIdQuery : IRequest<Result<RoleClaimDto>>
{
    [Required] public int Id { get; set; }
}
