namespace Domain.Interface.Helper;

using Microsoft.Extensions.Localization;
using System;

public interface IStringLocalizerHelper
{
    public IStringLocalizer GetStringLocalizer(Type source);
    public IStringLocalizer GetGlobalStringLocalizer();
}
