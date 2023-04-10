namespace Domain.Queries.Identity.User;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserController;
using MediatR;

public class GetUserAllQuery : IRequest<Result<UserDto[]>>
{
}
