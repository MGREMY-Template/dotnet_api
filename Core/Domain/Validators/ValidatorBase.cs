namespace Domain.Validators;

using Domain.Interface.Helper;
using FluentValidation;
using Microsoft.Extensions.Localization;

public abstract class ValidatorBase<T> : AbstractValidator<T>
{
    protected readonly IStringLocalizer _globalStringLocalizer;

    public ValidatorBase(IStringLocalizerHelper stringLocalizerHelper)
    {
        this._globalStringLocalizer = stringLocalizerHelper.GetGlobalStringLocalizer();
    }
}

public abstract class ValidatorBase<T, TStringLocalizerConstant> : ValidatorBase<T>
{
    protected readonly IStringLocalizer _stringLocalizer;

    public ValidatorBase(IStringLocalizerHelper stringLocalizerHelper) : base(stringLocalizerHelper)
    {
        this._stringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(TStringLocalizerConstant));
    }
}
