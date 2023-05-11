namespace Domain.Queries.Identity.Role;

using Domain.DataTransferObject;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

public class GetRoleByIdQuery : IRequest<Result<RoleDto>>
{
    [Required] public Guid Id { get; set; }
}
