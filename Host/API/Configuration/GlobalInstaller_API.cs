namespace API.Configuration;

using Domain.Attributes;
using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
