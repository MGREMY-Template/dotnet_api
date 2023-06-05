namespace Domain.Queries.Identity.UserClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Paging;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetUserClaimListQuery : IRequest<Result<UserClaimDto[]>>
{
    [Required] public IPaging Paging { get; set; }

    public GetUserClaimListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
