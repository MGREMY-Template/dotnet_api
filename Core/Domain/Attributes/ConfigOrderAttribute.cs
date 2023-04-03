namespace Domain.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ConfigOrderAttribute : Attribute
{
    public ConfigOrderAttribute(ushort order)
    {
        this.Order = order;
    }

    public ushort Order { get; set; }
}
