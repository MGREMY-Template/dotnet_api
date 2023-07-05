namespace Domain.Validators.Application.AppFile;

using Domain.Interface.Helper;
using Domain.Queries.Applciation.AppFile;
using Domain.Resources.Application;
using FluentValidation;
using Microsoft.Extensions.Localization;

public class GetAppFileListQueryValidator : ValidatorBase<GetAppFileListQuery>
{
    public GetAppFileListQueryValidator(IStringLocalizerHelper slh) : base(slh)
    {
        this.RuleFor(x => x.Paging)
            .NotNull()
            .WithMessage(this._globalStringLocalizer.GetString(GlobalConstants.PagingNull));
    }
}
