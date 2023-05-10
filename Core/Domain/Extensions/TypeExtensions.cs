namespace Domain.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class TypeExtensions
{
    public static bool PropertyExist(this Type type, string propertyName)
    {
        return type.GetTypeInfo().GetDeclaredProperty(propertyName) is not null;
    }

    public static T[] GetAllPublicConstantValues<T>(this Type type)
    {
        return type
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi =>
            {
                return fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(T);
            })
            .Select(x =>
            {
                return (T) x.GetRawConstantValue();
            })
            .ToArray();
    }
}
