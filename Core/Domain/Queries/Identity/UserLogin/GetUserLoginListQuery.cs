namespace Domain.Queries.Identity.UserLogin;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Paging;
using MediatR;

public class GetUserLoginListQuery : IRequest<Result<UserLoginDto[]>>
{
    public IPaging Paging { get; set; }

    public GetUserLoginListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
