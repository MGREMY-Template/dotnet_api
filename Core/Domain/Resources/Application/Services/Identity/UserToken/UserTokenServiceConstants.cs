namespace Domain.Resources.Application.Services.Identity.UserToken;

using Domain.Attributes;

[StringLocalizerTarget(typeof(UserTokenService))]
public class UserTokenServiceConstants
{
    public const string UserTokenNotFound = "UserTokenNotFound";
    public const string LoginProviderEmpty = "LoginProviderEmpty";
    public const string UserIdEmpty = "UserIdEmpty";
    public const string NameEmpty = "NameEmpty";
}
