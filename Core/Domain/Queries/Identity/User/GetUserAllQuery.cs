namespace Domain.Queries.Identity.User;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserController;
using MediatR;
using System.Collections.Generic;

public class GetUserAllQuery : IRequest<Result<UserDto[]>>
{
}
