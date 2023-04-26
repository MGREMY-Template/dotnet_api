namespace API.Configuration;

using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Domain.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

[ConfigOrder(0)]
public class ServiceInstaller_Swagger : IServiceInstaller
{
    public static Dictionary<string, OpenApiExample> AcceptedLanguages
    {
        get
        {
            return new()
            {
                { "fr-FR", new OpenApiExample{ Value = new OpenApiString("fr-FR") } },
                { "en-US", new OpenApiExample{ Value = new OpenApiString("en-US") } },
            };
        }
    }

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
                //c.AddSignalRSwaggerGen();

                c.OperationFilter<AcceptLanguageHeaderFilter>();
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

    private class AcceptLanguageHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Description = "Accept-Language value",
                Examples = AcceptedLanguages,
                Required = true,
                Schema = new OpenApiSchema { Type = "string" },
            });
        }
    }
}
