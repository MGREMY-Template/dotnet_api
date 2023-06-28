namespace Domain.Resources.Application.Services.Identity;

using Domain.Attributes;

[StringLocalizerTarget(typeof(UserTokenService))]
public class UserTokenServiceConstants
{
    public const string UserTokenNotFound = "UserTokenNotFound";
}
