namespace Domain.Validators.Identity.User;

using Domain.Interface.Helper;
using Domain.Queries.Identity.User;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserByIdQueryValidator : ValidatorBase<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.IdEmpty));
    }
}
