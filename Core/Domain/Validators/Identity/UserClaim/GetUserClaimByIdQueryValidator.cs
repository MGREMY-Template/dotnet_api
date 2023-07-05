namespace Domain.Validators.Identity.UserClaim;

using Domain.Interface.Helper;
using Domain.Queries.Identity.UserClaim;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserClaimByIdQueryValidator : ValidatorBase<GetUserClaimByIdQuery>
{
    public GetUserClaimByIdQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.IdEmpty));
    }
}
