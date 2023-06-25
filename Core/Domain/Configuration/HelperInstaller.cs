namespace Domain.Configuration;

using Domain.Helpers;
using Domain.Interface.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class HelperInstaller : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAppFileHelper, AppFileHelper>();
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
    }
}
