namespace Domain.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class StringLocalizerTargetAttribute : Attribute
{
    public StringLocalizerTargetAttribute(Type target)
    {
        this.Target = target;
    }

    public Type Target { get; set; }
}
