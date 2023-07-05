namespace Domain.Validators.Identity.UserRole;

using Domain.Interface.Helper;
using Domain.Queries.Identity.UserRole;
using Domain.Resources.Application.Services.Identity.UserRole;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserRoleByIdQueryValidator : ValidatorBase<GetUserRoleByIdQuery, UserRoleServiceConstants>
{
    public GetUserRoleByIdQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this._stringLocalizer.GetString(UserRoleServiceConstants.UserIdEmpty));

        this.RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage(this._stringLocalizer.GetString(UserRoleServiceConstants.RoleIdEmpty));
    }
}
