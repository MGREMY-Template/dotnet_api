namespace Domain.Configuration;

using Domain;
using Domain.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[ConfigOrder(0)]
public class AutoMapperInstaller : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddAutoMapper(typeof(Marker).Assembly);
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
    }
}
