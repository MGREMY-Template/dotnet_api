namespace Shared.Core.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class DependencyInjection
{
    public static IServiceCollection Configure(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        IEnumerable<IServiceInstaller> serviceInstallers = assemblies
            .SelectMany(a =>
            {
                return a.DefinedTypes;
            })
            .Where(IsAssignableToType<IServiceInstaller>)
            .OrderBy<TypeInfo, int>(a =>
            {
                Attribute[] attrs = Attribute.GetCustomAttributes(a);

                foreach (Attribute attr in attrs)
                {
                    if (attr is ConfigOrderAttribute coa)
                    {
                        return coa.Order;
                    }
                }

                return -1;

            })
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();

        foreach (IServiceInstaller serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Configure(services, configuration);
        }

        return services;

        static bool IsAssignableToType<T>(TypeInfo typeInfo)
        {
            return typeof(T).IsAssignableFrom(typeInfo)
            && !typeInfo.IsInterface
            && !typeInfo.IsAbstract;
        }
    }
}
