namespace Domain.Queries.Identity.UserToken;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Paging;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetUserTokenListQuery : IRequest<Result<UserTokenDto[]>>
{
    [Required] public IPaging Paging { get; set; }

    public GetUserTokenListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
