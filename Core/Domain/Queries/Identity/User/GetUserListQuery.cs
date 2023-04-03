namespace Domain.Queries.Identity.User;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserController;
using Domain.Paging;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetUserListQuery : IRequest<Result<UserDto[]>>
{
    [Required] public IPaging Paging { get; set; }

    public GetUserListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
