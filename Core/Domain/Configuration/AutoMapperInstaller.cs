namespace Domain.Configuration;

using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Attributes;

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
