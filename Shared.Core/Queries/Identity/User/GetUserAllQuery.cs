using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using System.Collections.Generic;

namespace Shared.Core.Queries.Identity.User
{
    public class GetUserAllQuery : IRequest<Result<IEnumerable<UserDto>>>
    {
    }
}
