namespace Domain.Extensions;

using System;
using System.Linq;
using System.Reflection;

public static class TypeExtensions
{
    public static bool PropertyExist(this Type type, string propertyName, out string realPropertyName)
    {
        if (type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) is PropertyInfo property)
        {
            realPropertyName = property.Name;
            return true;
        }

        realPropertyName = string.Empty;
        return false;
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
