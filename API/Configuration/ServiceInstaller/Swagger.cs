using Domain.Attribute;
using Domain.Configuration;
using Microsoft.OpenApi.Models;

namespace API.Configuration.ServiceInstaller;

[ServiceInstallerOrder(0)]
public class Swagger : IServiceInstaller
{
    public WebApplicationBuilder Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(config =>
            {
                config.ResolveConflictingActions(apiDescription => apiDescription.First());
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BACKEND API",
                    Version = "v1",
                    Description = "BACKEND API Service",
                    Contact = new OpenApiContact
                    {
                        Name = "LASTNAME Firstname",
                        Email = "mastname.firstname@email.com",
                    }
                });
            })
            .AddEndpointsApiExplorer();

        return builder;
    }

    public WebApplication Install(WebApplication application)
    {
        if (application.Environment.IsDevelopment())
        {
            application
                .UseSwagger()
                .UseSwaggerUI();
        }

        return application;
    }
}