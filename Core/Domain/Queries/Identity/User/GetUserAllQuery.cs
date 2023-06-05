namespace Domain.Queries.Identity.User;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class GetUserAllQuery : IRequest<Result<UserDto[]>>
{
}
