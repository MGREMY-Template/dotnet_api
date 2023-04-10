namespace API.Configuration;

using API.Hubs;
using Domain.Attributes;
using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[ConfigOrder(0)]
public class ServiceInstaller_SignalR : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddSignalR()
            .AddJsonProtocol();
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
        ((IEndpointRouteBuilder) applicationBuilder).MapHub<NotificationHub>("hub/notification");
    }
}
