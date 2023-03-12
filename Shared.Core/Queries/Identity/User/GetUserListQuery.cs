using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Domain.Specification;
using System.Collections.Generic;

namespace Shared.Core.Queries.Identity.User
{
    public class GetUserListQuery : IRequest<Result<IEnumerable<UserDto>>>
    {
        public IPaging Paging { get; set; }

        public GetUserListQuery(IPaging paging)
        {
            Paging = paging;
        }
    }
}
