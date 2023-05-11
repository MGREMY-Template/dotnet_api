namespace Domain.Queries.Identity.UserRole;

using Domain.DataTransferObject;
using MediatR;

public class GetUserRoleAllQuery : IRequest<Result<UserRoleDto[]>>
{
}
