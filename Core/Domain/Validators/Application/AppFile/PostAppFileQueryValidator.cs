namespace Domain.Validators.Application.AppFile;

using Domain.Interface.Helper;
using Domain.Queries.Applciation.AppFile;
using Domain.Resources.Application.Services.Application.AppFile;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class PostAppFileQueryValidator : ValidatorBase<PostAppFileQuery, AppFileServiceConstants>
{
    public PostAppFileQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.File)
            .NotNull()
            .WithMessage(this._stringLocalizer.GetString(AppFileServiceConstants.FileNull));
    }
}
