namespace API;

using API.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Core.Configuration;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        _ = builder.Configuration.AddEnvironmentVariables(prefix: "APP_CFG");

        _ = builder.Services
            .Configure(
                builder.Configuration,
                typeof(Program).Assembly,
                typeof(Shared.Application.Marker).Assembly,
                typeof(Shared.Infrastructure.Marker).Assembly,
                typeof(Shared.Core.Marker).Assembly);

        // Add services to the container
        _ = builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = builder.Services.AddEndpointsApiExplorer();

        WebApplication app = builder.Build();

        RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(ServiceInstaller_Swagger.AcceptedLanguages.Keys.FirstOrDefault())
            .AddSupportedCultures(ServiceInstaller_Swagger.AcceptedLanguages.Keys.ToArray())
            .AddSupportedUICultures(ServiceInstaller_Swagger.AcceptedLanguages.Keys.ToArray());
        localizationOptions.ApplyCurrentCultureToResponseHeaders = true;

        _ = app.UseRequestLocalization(localizationOptions);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI();
        }

        _ = app.UseAuthentication();
        _ = app.UseAuthorization();

        _ = app.MapControllers();

        app.Run();
    }
}