namespace Domain.Validators.Identity.Role;

using Domain.Interface.Helper;
using Domain.Queries.Identity.Role;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetRoleListQueryValidator : ValidatorBase<GetRoleListQuery>
{
    public GetRoleListQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Paging)
            .NotNull()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.PagingNull));
    }
}
