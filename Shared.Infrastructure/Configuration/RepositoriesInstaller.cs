namespace Shared.Infrastructure.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Attributes;
using Shared.Core.Configuration;
using System.Linq;
using System.Reflection;

[ConfigOrder(1)]
public class RepositoriesInstaller : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        var types = typeof(Shared.Core.Marker)
            .Assembly.DefinedTypes.AsEnumerable()
            .Where(IsInterfaceRepository)
            .Select(i =>
            {
                return new
                {
                    Interface = i,
                    Implementation = typeof(Shared.Infrastructure.Marker).Assembly.DefinedTypes
                        .FirstOrDefault(ri =>
                        {
                            return IsAssignableToType(i, ri);
                        }),
                };
            }).Where(x =>
            {
                return x.Implementation is not null;
            });

        foreach (var type in types)
        {
            _ = services.AddScoped(type.Interface, type.Implementation);
        }

        static bool IsAssignableToType(TypeInfo typeInfo, TypeInfo implementation)
        {
            return typeInfo.IsAssignableFrom(implementation)
            && !implementation.IsInterface
            && !implementation.IsAbstract;
        }

        static bool IsInterfaceRepository(TypeInfo typeInfo)
        {
            return typeInfo.Name.StartsWith("I")
            && typeInfo.Name.EndsWith("Repository")
            && typeInfo.IsInterface;
        }
    }
}
