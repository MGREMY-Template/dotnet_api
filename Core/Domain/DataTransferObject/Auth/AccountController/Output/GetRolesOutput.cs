namespace Domain.DataTransferObject.Auth.AccountController.Output;

using Domain.DataTransferObject;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record GetRolesOutput
{
    [Required, DisplayName("Roles")] public RoleDto[] Roles { get; set; }
}
