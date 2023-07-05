namespace Domain.Validators.Application.AppFile;

using Domain.Interface.Helper;
using Domain.Queries.Applciation.AppFile;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetAppFileBytesQueryValidator : ValidatorBase<GetAppFileBytesQuery>
{
    public GetAppFileBytesQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.AppFileId)
            .NotEmpty()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.IdEmpty));
    }
}
