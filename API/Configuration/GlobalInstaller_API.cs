namespace API.Configuration;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Attributes;
using Shared.Core.Configuration;

[ConfigOrder(3)]
public sealed partial class GlobalInstaller_API : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddControllers();
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
    }
}
