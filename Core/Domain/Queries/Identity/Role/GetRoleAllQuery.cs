namespace Domain.Queries.Identity.Role;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.RoleController;
using MediatR;

public class GetRoleAllQuery : IRequest<Result<RoleDto[]>>
{
}
