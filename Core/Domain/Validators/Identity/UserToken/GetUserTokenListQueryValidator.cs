namespace Domain.Validators.Identity.UserToken;

using Domain.Interface.Helper;
using Domain.Queries.Identity.UserToken;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserTokenListQueryValidator : ValidatorBase<GetUserTokenListQuery>
{
    public GetUserTokenListQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Paging)
            .NotNull()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.PagingNull));
    }
}
