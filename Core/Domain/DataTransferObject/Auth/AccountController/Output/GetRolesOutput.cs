namespace Domain.DataTransferObject.Auth.AccountController.Output;

using Domain.DataTransferObject.Identity;

public record GetRolesOutput
{
    public RoleDto[] Roles { get; set; }
}
