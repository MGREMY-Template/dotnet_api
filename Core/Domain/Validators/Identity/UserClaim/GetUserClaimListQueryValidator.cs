namespace Domain.Validators.Identity.UserClaim;

using Domain.Interface.Helper;
using Domain.Queries.Identity.UserClaim;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserClaimListQueryValidator : ValidatorBase<GetUserClaimListQuery>
{
    public GetUserClaimListQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Paging)
            .NotNull()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.PagingNull));
    }
}
