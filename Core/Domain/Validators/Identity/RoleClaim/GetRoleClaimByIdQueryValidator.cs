namespace Domain.Validators.Identity.RoleClaim;

using Domain.Interface.Helper;
using Domain.Queries.Identity.RoleClaim;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetRoleClaimByIdQueryValidator : ValidatorBase<GetRoleClaimByIdQuery>
{
    public GetRoleClaimByIdQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.IdEmpty));
    }
}
