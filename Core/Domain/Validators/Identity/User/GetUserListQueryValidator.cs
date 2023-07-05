namespace Domain.Validators.Identity.User;

using Domain.Interface.Helper;
using Domain.Queries.Identity.User;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetUserListQueryValidator : ValidatorBase<GetUserListQuery>
{
    public GetUserListQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Paging)
            .NotNull()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.PagingNull));
    }
}
