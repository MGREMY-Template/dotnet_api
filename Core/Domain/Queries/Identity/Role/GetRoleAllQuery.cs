namespace Domain.Queries.Identity.Role;

using Domain.DataTransferObject;
using MediatR;

public class GetRoleAllQuery : IRequest<Result<RoleDto[]>>
{
}
