namespace Domain.Resources.Application.Services.Auth.Auth;

using Domain.Attributes;

[StringLocalizerTarget(typeof(AuthService))]
public class AuthServiceConstants
{
    #region EMAIL
    public const string EmailEmpty = "EmailEmpty";
    public const string EmailInvalidFormat = "EmailInvalidFormat";
    public const string EmailAlreadyConfirmed = "EmailAlreadyConfirmed";
    public const string EmailConfirmationError = "EmailConfirmationError";
    #endregion
    #region PASSWORD
    public const string PasswordEmpty = "PasswordEmpty";
    public const string PasswordIncorrect = "PasswordIncorrect";
    #endregion
    #region USERNAME
    public const string UserNameEmpty = "UserNameEmpty";
    #endregion
    #region USER
    public const string UserNotFound = "UserNotFound";
    public const string UserAlreadyExists = "UserAlreadyExists";
    #endregion
    #region OTHER
    public const string UserSignInError = "UserSignInError";
    public const string TokenEmpty = "TokenEmpty";
    #endregion
}
