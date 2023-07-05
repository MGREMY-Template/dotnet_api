namespace Domain.Queries.Identity.UserRole;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;
using System;

public class GetUserRoleByIdQuery : IRequest<Result<UserRoleDto>>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}
