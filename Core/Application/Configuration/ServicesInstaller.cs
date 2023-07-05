namespace Application.Configuration;

using Domain.Attributes;
using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[ConfigOrder(1)]
public class ServicesInstaller : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddMediatR(conf =>
            {
                _ = conf.RegisterServicesFromAssembly(typeof(Marker).Assembly);
            });
    }

    public void Install(WebApplication applicationBuilder)
    {
    }
}
