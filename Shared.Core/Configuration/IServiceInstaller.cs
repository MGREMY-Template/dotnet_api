namespace Shared.Core.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public interface IServiceInstaller
{
    void Configure(IServiceCollection services, IConfiguration configuration);
}
