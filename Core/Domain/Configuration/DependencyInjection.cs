namespace Domain.Configuration;

using Domain.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        IEnumerable<IServiceInstaller> serviceInstallers = GetServiceInstallers(assemblies);

        foreach (IServiceInstaller serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Configure(services, configuration);
        }

        return services;
    }

    public static WebApplication Install(
        this WebApplication applicationBuilder,
        params Assembly[] assemblies)
    {
        IEnumerable<IServiceInstaller> serviceInstallers = GetServiceInstallers(assemblies);

        foreach (IServiceInstaller serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(applicationBuilder);
        }

        return applicationBuilder;
    }

    private static IEnumerable<IServiceInstaller> GetServiceInstallers(params Assembly[] assemblies)
    {
        return assemblies
            .SelectMany(a =>
            {
                return a.DefinedTypes;
            })
            .Where(IsAssignableToType<IServiceInstaller>)
            .OrderBy(a =>
            {
                return Attribute.GetCustomAttribute(a, typeof(ConfigOrderAttribute)) is ConfigOrderAttribute attr
                    ? attr.Order
                    : -1;
            })
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();
    }

    private static bool IsAssignableToType<T>(TypeInfo typeInfo)
    {
        return typeof(T).IsAssignableFrom(typeInfo)
        && !typeInfo.IsInterface
        && !typeInfo.IsAbstract;
    }
}
