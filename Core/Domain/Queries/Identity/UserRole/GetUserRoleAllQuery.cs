namespace Domain.Queries.Identity.UserRole;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class GetUserRoleAllQuery : IRequest<Result<UserRoleDto[]>>
{
}
