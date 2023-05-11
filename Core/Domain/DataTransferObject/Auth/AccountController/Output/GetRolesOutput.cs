namespace Domain.DataTransferObject.Auth.AccountController.Output;

using Domain.DataTransferObject;

public record GetRolesOutput
{
    public RoleDto[] Roles { get; set; }
}
