using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Configuration;
using System.Linq;
using System.Reflection;
using System;
using Shared.Core.Attributes;

namespace Shared.Application.Configuration
{
    [ConfigOrder(1)]
    public class ServicesInstaller : IServiceInstaller
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var types = typeof(Shared.Core.Marker)
                .Assembly.DefinedTypes.AsEnumerable()
                .Where(IsInterfaceService)
                .Select(i => new
                {
                    Interface = i,
                    Implementation = typeof(Shared.Application.Marker).Assembly.DefinedTypes
                        .FirstOrDefault(ri => IsAssignableToType(i, ri) || IsAssignableToGenericType(i, ri)),
                }).Where(x => x.Implementation is not null);

            foreach (var type in types)
            {
                services.AddTransient(type.Interface, type.Implementation);
            }

            static bool IsAssignableToType(TypeInfo typeInfo, TypeInfo implementation) =>
                typeInfo.IsAssignableFrom(implementation)
                && !implementation.IsInterface
                && !implementation.IsAbstract;

            static bool IsAssignableToGenericType(Type typeInfo, Type implementation)
            {
                var interfaceTypes = implementation.GetInterfaces();

                foreach (var it in interfaceTypes)
                {
                    if (it.IsGenericType && it.GetGenericTypeDefinition() == typeInfo)
                        return true;
                }

                if (implementation.IsGenericType && implementation.GetGenericTypeDefinition() == typeInfo)
                    return true;

                Type baseType = implementation.BaseType;
                if (baseType == null) return false;

                return IsAssignableToGenericType(baseType, typeInfo);
            }

            static bool IsInterfaceService(TypeInfo typeinfo) =>
                typeinfo.Name.StartsWith("I")
                && typeinfo.Name.Contains("Service")
                && typeinfo.IsInterface;
        }
    }
}
