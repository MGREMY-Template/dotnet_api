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
        return Attribute.GetCustomAttribute(source, typeof(StringLocalizerTargetAttribute)) is StringLocalizerTargetAttribute attribute
            ? this._factory.Create(attribute.Target)
            : throw new ArgumentException("Class doesn't have StringLocalizerTarget attribute", nameof(source));
    }
}
