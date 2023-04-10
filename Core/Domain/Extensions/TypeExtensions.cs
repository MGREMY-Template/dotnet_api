namespace Domain.Extensions;

using System;
using System.Reflection;

public static class TypeExtensions
{
    public static bool PropertyExist(this Type type, string propertyName)
    {
        return type.GetTypeInfo().GetDeclaredProperty(propertyName) is not null;
    }
}
