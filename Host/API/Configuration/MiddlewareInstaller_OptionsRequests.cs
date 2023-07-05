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
                _ = policy.SetIsOriginAllowed((host) =>
                    {
                        return true;
                    });
                _ = policy.AllowAnyMethod();
                _ = policy.AllowAnyHeader();
                _ = policy.AllowCredentials();
            });
        });
    }

    public void Install(WebApplication applicationBuilder)
    {
        _ = applicationBuilder.UseCors();
    }
}
