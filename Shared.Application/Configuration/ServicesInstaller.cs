using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Configuration;
using System.Linq;
using System.Reflection;
using Shared.Core.Attributes;

namespace Shared.Application.Configuration
{
    [ConfigOrder(1)]
    public class ServicesInstaller : IServiceInstaller
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(typeof(Shared.Application.Marker).Assembly);
            });
        }
    }
}
