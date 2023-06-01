namespace API.Configuration;

using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class MiddlewareInstaller_OptionsRequests : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
            });
        });
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseCors();
    }
}
