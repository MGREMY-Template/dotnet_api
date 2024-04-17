using System.Reflection;
using Domain.Attribute;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Domain.Configuration;

public static class DependencyInjection
{
    public static WebApplicationBuilder Configure(this WebApplicationBuilder applicationBuilder,
        params Assembly[] assemblies)
    {
        var serviceInstallers = GetServiceInstallers(assemblies);

        foreach (var serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Configure(applicationBuilder);
        }

        return applicationBuilder;
    }

    public static WebApplication Install(this WebApplication webApplication,
        params Assembly[] assemblies)
    {
        var serviceInstallers = GetServiceInstallers(assemblies);

        foreach (var serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(webApplication);
        }

        return webApplication;
    }

    private static IEnumerable<IServiceInstaller> GetServiceInstallers(IEnumerable<Assembly> assemblies)
    {
        return assemblies
            .SelectMany(assembly => assembly.DefinedTypes)
            .Where(IsAssignableToType<IServiceInstaller>)
            .OrderBy(defType =>
                System.Attribute.GetCustomAttribute(defType, typeof(ServiceInstallerOrderAttribute)) is
                    ServiceInstallerOrderAttribute attribute
                    ? attribute.Order
                    : -1)
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();

        static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
            typeof(T).IsAssignableFrom(typeInfo)
            && typeInfo is { IsAbstract: false, IsInterface: false };
    }
}