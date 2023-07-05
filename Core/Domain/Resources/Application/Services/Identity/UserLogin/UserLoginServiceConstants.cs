namespace Domain.Resources.Application.Services.Identity.UserLogin;

using Domain.Attributes;

[StringLocalizerTarget(typeof(UserLoginService))]
public class UserLoginServiceConstants
{
    public const string UserLoginNotFound = "UserLoginNotFound";
    public const string LoginProviderEmpty = "LoginProviderEmpty";
    public const string ProviderKeyEmpty = "ProviderKeyEmpty";
}
