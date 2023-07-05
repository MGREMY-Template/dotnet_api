namespace Domain.Resources.Application.Services.Identity.UserRole;

using Domain.Attributes;

[StringLocalizerTarget(typeof(UserRoleService))]
public class UserRoleServiceConstants
{
    public const string UserRoleNotFound = "UserRoleNotFound";
    public const string UserIdEmpty = "UserIdEmpty";
    public const string RoleIdEmpty = "RoleIdEmpty";
}
