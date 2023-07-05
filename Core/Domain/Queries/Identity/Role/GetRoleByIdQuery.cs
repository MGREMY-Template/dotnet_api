namespace Domain.Queries.Identity.Role;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;
using System;

public class GetRoleByIdQuery : IRequest<Result<RoleDto>>
{
    public Guid Id { get; set; }
}
