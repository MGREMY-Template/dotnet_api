namespace Domain.Queries.Identity.User;

using Domain.DataTransferObject;
using MediatR;

public class GetUserAllQuery : IRequest<Result<UserDto[]>>
{
}
