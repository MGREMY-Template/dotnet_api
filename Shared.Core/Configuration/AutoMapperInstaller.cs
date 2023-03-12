using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Core.Configuration
{
    public class AutoMapperInstaller : IServiceInstaller
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Shared.Core.Marker).Assembly);
        }
    }
}
