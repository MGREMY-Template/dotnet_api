using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Attributes;
using Shared.Core.Configuration;

namespace API.Configuration
{
	[ConfigOrder(2)]
	public class LayerInstaller_Authorization : IServiceInstaller
	{
		public void Configure(IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthorization();
		}
	}
}
