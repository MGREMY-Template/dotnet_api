namespace Shared.Core.Queries.Identity.User;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Paging;
using System.Collections.Generic;

public class GetUserListQuery : IRequest<Result<UserDto[]>>
{
    public IPaging Paging { get; set; }

    public GetUserListQuery(IPaging paging)
    {
        this.Paging = paging;
    }
}
