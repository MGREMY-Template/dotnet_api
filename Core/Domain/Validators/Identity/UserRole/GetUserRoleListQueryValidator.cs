namespace Domain.Validators.Identity.UserRole;

using Domain.Interface.Helper;
using Domain.Queries.Identity.UserRole;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserRoleListQueryValidator : ValidatorBase<GetUserRoleListQuery>
{
    public GetUserRoleListQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Paging)
            .NotNull()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.PagingNull));
    }
}
