namespace Domain.Queries.Identity.UserRole;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Paging;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetUserRoleListQuery : IRequest<Result<UserRoleDto[]>>
{
    [Required] public IPaging Paging { get; set; }

    public GetUserRoleListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
