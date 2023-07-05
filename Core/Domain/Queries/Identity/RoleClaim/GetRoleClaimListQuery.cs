namespace Domain.Queries.Identity.RoleClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Paging;
using MediatR;

public class GetRoleClaimListQuery : IRequest<Result<RoleClaimDto[]>>
{
    public IPaging Paging { get; set; }

    public GetRoleClaimListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
