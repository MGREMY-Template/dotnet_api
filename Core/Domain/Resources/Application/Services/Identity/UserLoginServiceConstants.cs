namespace Domain.Resources.Application.Services.Identity;

using Domain.Attributes;

[StringLocalizerTarget(typeof(UserLoginService))]
public class UserLoginServiceConstants
{
    public const string UserLoginNotFound = "UserLoginNotFound";
}
