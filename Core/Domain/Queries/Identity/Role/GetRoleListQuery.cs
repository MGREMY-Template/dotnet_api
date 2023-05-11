namespace Domain.Queries.Identity.Role;

using Domain.DataTransferObject;
using Domain.Paging;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetRoleListQuery : IRequest<Result<RoleDto[]>>
{
    [Required] public IPaging Paging { get; set; }

    public GetRoleListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
