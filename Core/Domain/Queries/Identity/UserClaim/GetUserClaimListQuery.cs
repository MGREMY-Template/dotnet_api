namespace Domain.Queries.Identity.UserClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Paging;
using MediatR;

public class GetUserClaimListQuery : IRequest<Result<UserClaimDto[]>>
{
    public IPaging Paging { get; set; }

    public GetUserClaimListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
