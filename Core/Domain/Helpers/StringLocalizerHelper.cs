namespace Domain.Helpers;

using Domain.Attributes;
using Domain.Interface.Helper;
using Microsoft.Extensions.Localization;
using System;

public class StringLocalizerHelper : IStringLocalizerHelper
{
    private readonly IStringLocalizerFactory _factory;
    public StringLocalizerHelper(
        IStringLocalizerFactory factory)
    {
        this._factory = factory;
    }

    public IStringLocalizer GetStringLocalizer(Type source)
    {
        if (Attribute.GetCustomAttribute(source, typeof(StringLocalizerTargetAttribute)) is StringLocalizerTargetAttribute attribute)
        {
            var target = attribute.Target;

            return this._factory.Create(target);
        }
        else
        {
            throw new ArgumentException("Class doesn't have StringLocalizerTarget attribute", nameof(source));
        }
    }
}
