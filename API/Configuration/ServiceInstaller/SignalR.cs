using Domain.Configuration;

namespace API.Configuration.ServiceInstaller;

public class SignalR : IServiceInstaller
{
    public WebApplicationBuilder Configure(WebApplicationBuilder builder)
    {
        builder.Services
            .AddSignalR()
            .AddJsonProtocol();

        return builder;
    }

    public WebApplication Install(WebApplication application)
    {
        return application;
    }
}