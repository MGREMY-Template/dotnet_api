namespace API.Configuration;

using Domain.Attributes;
using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;

[ConfigOrder(0)]
public class ServiceInstaller_Swagger : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions =>
                {
                    return apiDescriptions.First();
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GREMY.OVH API",
                    Version = "v1",
                    Description = "GREMY.OVH API Service",
                    Contact = new OpenApiContact
                    {
                        Name = "GREMY Miguel",
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

        _ = services.AddEndpointsApiExplorer();
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
        if (applicationBuilder.ApplicationServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment())
        {
            _ = applicationBuilder.UseSwagger();
            _ = applicationBuilder.UseSwaggerUI();
        }
    }
}
