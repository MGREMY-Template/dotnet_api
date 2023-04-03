namespace API.Configuration;

using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Attributes;
using System.Linq;

[ConfigOrder(0)]
public class ServiceInstaller_Localization : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddLocalization(opt =>
            {

            });
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
        RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(ServiceInstaller_Swagger.AcceptedLanguages.Keys.FirstOrDefault())
            .AddSupportedCultures(ServiceInstaller_Swagger.AcceptedLanguages.Keys.ToArray())
            .AddSupportedUICultures(ServiceInstaller_Swagger.AcceptedLanguages.Keys.ToArray());
        localizationOptions.ApplyCurrentCultureToResponseHeaders = true;

        _ = applicationBuilder.UseRequestLocalization(localizationOptions);
    }
}
