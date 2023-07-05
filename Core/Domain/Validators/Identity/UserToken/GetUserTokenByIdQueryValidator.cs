namespace Domain.Validators.Identity.UserToken;

using Domain.Interface.Helper;
using Domain.Queries.Identity.UserToken;
using Domain.Resources.Application.Services.Identity.UserToken;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserTokenByIdQueryValidator : ValidatorBase<GetUserTokenByIdQuery, UserTokenServiceConstants>
{
    public GetUserTokenByIdQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.LoginProvider)
            .NotEmpty()
            .WithMessage(this._stringLocalizer.GetString(UserTokenServiceConstants.LoginProviderEmpty));

        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this._stringLocalizer.GetString(UserTokenServiceConstants.UserIdEmpty));

        this.RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(this._stringLocalizer.GetString(UserTokenServiceConstants.NameEmpty));
    }
}
