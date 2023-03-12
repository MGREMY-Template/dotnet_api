using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Attributes;
using Shared.Core.Configuration;
using Shared.Core.Interface.Repository;
using Shared.Infrastructure.Repositories;

namespace Shared.Infrastructure.Configuration
{
    [ConfigOrder(1)]
    public class GlobalInstaller : IServiceInstaller
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IUnitOfWork<,>), typeof(UnitOfWork<,>));
        }
    }
}
