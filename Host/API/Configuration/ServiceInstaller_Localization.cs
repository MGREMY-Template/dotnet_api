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
    public static string[] AcceptedLanguages
    {
        get
        {
            return new[] { "fr-FR", "en-US" };
        }
    }

    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddLocalization(opt =>
            {

            });
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
        RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(AcceptedLanguages.FirstOrDefault())
            .AddSupportedCultures(AcceptedLanguages)
            .AddSupportedUICultures(AcceptedLanguages);
        localizationOptions.ApplyCurrentCultureToResponseHeaders = true;

        _ = applicationBuilder.UseRequestLocalization(localizationOptions);
    }
}
