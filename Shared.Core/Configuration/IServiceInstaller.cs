using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Core.Configuration
{
    public interface IServiceInstaller
    {
        void Configure(IServiceCollection services, IConfiguration configuration);
    }
}
