using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Attributes;
using Shared.Core.Configuration;
using System.Linq;
using System.Reflection;

namespace API.Configuration
{
	[ConfigOrder(1)]
	public class ProjectInstaller_Application : IServiceInstaller
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
						.FirstOrDefault(ri => IsAssignableToType(i, ri)),
				}).Where(x => x.Implementation is not null);

			foreach (var type in types)
			{
				services.AddTransient(type.Interface, type.Implementation);
			}

			static bool IsAssignableToType(TypeInfo typeInfo, TypeInfo implementation) =>
				typeInfo.IsAssignableFrom(implementation)
				&& !implementation.IsInterface
				&& !implementation.IsAbstract;

			static bool IsInterfaceService(TypeInfo typeinfo) =>
				typeinfo.Name.StartsWith("I")
				&& typeinfo.Name.Contains("Service")
				&& typeinfo.IsInterface;
		}
	}
}
