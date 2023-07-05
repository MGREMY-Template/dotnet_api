namespace Domain.Validators.Identity.RoleClaim;

using Domain.Interface.Helper;
using Domain.Queries.Identity.RoleClaim;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetRoleClaimListQueryValidator : ValidatorBase<GetRoleClaimListQuery>
{
    public GetRoleClaimListQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Paging)
            .NotNull()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.PagingNull));
    }
}
