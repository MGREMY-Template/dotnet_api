namespace API.Configuration;

using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Attributes;

[ConfigOrder(2)]
public class LayerInstaller_Authorization : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddAuthorization();
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
        _ = applicationBuilder.UseAuthorization();
    }
}
