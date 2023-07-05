namespace Domain.Queries.Identity.Role;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Paging;
using MediatR;

public class GetRoleListQuery : IRequest<Result<RoleDto[]>>
{
    public IPaging Paging { get; set; }

    public GetRoleListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
