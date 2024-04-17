using Domain.Attribute;
using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration;

[ServiceInstallerOrder(1)]
public class MediatR : IServiceInstaller
{
    public WebApplicationBuilder Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(serviceConfiguration =>
            serviceConfiguration.RegisterServicesFromAssembly(typeof(Application.Marker).Assembly)
        );

        return builder;
    }

    public WebApplication Install(WebApplication application)
    {
        return application;
    }
}