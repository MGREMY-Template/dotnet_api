namespace Domain.Validators.Identity.UserLogin;

using Domain.Interface.Helper;
using Domain.Queries.Identity.UserLogin;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserLoginListQueryValidator : ValidatorBase<GetUserLoginListQuery>
{
    public GetUserLoginListQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Paging)
            .NotNull()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.PagingNull));
    }
}
