using Domain.Attribute;
using Domain.Configuration;

namespace API.Configuration.LayerInstaller;

[ServiceInstallerOrder(2)]
public class Authorization : IServiceInstaller
{
    public WebApplicationBuilder Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization();

        return builder;
    }

    public WebApplication Install(WebApplication application)
    {
        return application;
    }
}