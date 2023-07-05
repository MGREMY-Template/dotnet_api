namespace Domain.Validators.Identity.UserLogin;

using Domain.Interface.Helper;
using Domain.Queries.Identity.UserLogin;
using Domain.Resources.Application.Services.Identity.UserLogin;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserLoginByIdQueryValidator : ValidatorBase<GetUserLoginByIdQuery, UserLoginServiceConstants>
{
    public GetUserLoginByIdQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.LoginProvider)
            .NotEmpty()
            .WithMessage(this._stringLocalizer.GetString(UserLoginServiceConstants.LoginProviderEmpty));

        this.RuleFor(x => x.ProviderKey)
            .NotEmpty()
            .WithMessage(this._stringLocalizer.GetString(UserLoginServiceConstants.ProviderKeyEmpty));
    }
}
