namespace Domain.Resources.Application.Services.Identity;

using Domain.Attributes;

[StringLocalizerTarget(typeof(UserService))]
public class UserServiceConstants
{
    public const string UserNotFound = "UserNotFound";
}
