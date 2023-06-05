namespace Domain.Queries.Identity.UserRole;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

public class GetUserRoleByIdQuery : IRequest<Result<UserRoleDto>>
{
    [Required] public Guid UserId { get; set; }
    [Required] public Guid RoleId { get; set; }
}
