namespace Domain.Queries.Identity.UserRole;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserRoleController;
using MediatR;

public class GetUserRoleAllQuery : IRequest<Result<UserRoleDto[]>>
{
}
