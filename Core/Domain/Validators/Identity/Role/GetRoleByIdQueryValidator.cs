namespace Domain.Validators.Identity.Role;

using Domain.Interface.Helper;
using Domain.Queries.Identity.Role;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetRoleByIdQueryValidator : ValidatorBase<GetRoleByIdQuery>
{
    public GetRoleByIdQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.IdEmpty));
    }
}
