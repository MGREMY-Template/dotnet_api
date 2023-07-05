namespace Domain.Queries.Identity.User;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Paging;
using MediatR;

public class GetUserListQuery : IRequest<Result<UserDto[]>>
{
    public IPaging Paging { get; set; }

    public GetUserListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
