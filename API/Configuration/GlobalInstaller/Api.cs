using Domain.Attribute;
using Domain.Configuration;

namespace API.Configuration.GlobalInstaller;

[ServiceInstallerOrder(3)]
public class Api : IServiceInstaller
{
    public WebApplicationBuilder Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        return builder;
    }

    public WebApplication Install(WebApplication application) => application;
}