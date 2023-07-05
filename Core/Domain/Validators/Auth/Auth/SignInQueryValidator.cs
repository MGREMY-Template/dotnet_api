namespace Domain.Validators.Auth.Auth;

using Domain.Interface.Helper;
using Domain.Queries.Auth.Auth;
using Domain.Resources.Application.Services.Auth.Auth;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class SignInQueryValidator : ValidatorBase<SignInQuery, AuthServiceConstants>
{
    public SignInQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(this._stringLocalizer.GetString(AuthServiceConstants.EmailEmpty))
            .EmailAddress()
            .WithMessage(this._stringLocalizer.GetString(AuthServiceConstants.EmailInvalidFormat));

        this.RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(this._stringLocalizer.GetString(AuthServiceConstants.PasswordEmpty));
    }
}
