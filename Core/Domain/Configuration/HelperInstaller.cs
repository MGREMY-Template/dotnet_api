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
        _ = services.AddSingleton<IAppFileHelper, AppFileHelper>();
        _ = services.AddSingleton<IStringLocalizerHelper, StringLocalizerHelper>();
    }

    public void Install(WebApplication applicationBuilder)
    {
    }
}
