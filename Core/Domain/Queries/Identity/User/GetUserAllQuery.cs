namespace Shared.Core.Queries.Identity.User;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using System.Collections.Generic;

public class GetUserAllQuery : IRequest<Result<UserDto[]>>
{
}
