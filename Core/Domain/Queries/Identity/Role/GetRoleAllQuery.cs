namespace Domain.Queries.Identity.Role;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;

public class GetRoleAllQuery : IRequest<Result<RoleDto[]>>
{
}
