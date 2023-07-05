namespace Domain.Validators.Application.AppFile;

using Domain.Interface.Helper;
using Domain.Queries.Applciation.AppFile;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetAppFileByIdQueryValidator : ValidatorBase<GetAppFileByIdQuery>
{
    public GetAppFileByIdQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.IdEmpty));
    }
}
