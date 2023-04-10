namespace Domain.Queries.Identity.Role;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserController;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

public class GetRoleByIdQuery : IRequest<Result<UserDto>>
{
    [Required] public Guid Id { get; set; }
}
