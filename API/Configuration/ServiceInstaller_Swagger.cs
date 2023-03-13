namespace API.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Shared.Core.Attributes;
using Shared.Core.Configuration;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

[ConfigOrder(0)]
public class ServiceInstaller_Swagger : IServiceInstaller
{
    public static Dictionary<string, OpenApiExample> AcceptedLanguages =>
        new()
        {
            { "fr-FR", new OpenApiExample{ Value = new OpenApiString("fr-FR") } },
            { "en-US", new OpenApiExample{ Value = new OpenApiString("en-US") } },
        };

    public void Configure(IServiceCollection services, IConfiguration configuration) => services.AddSwaggerGen(c =>
                                                                                                 {
                                                                                                     c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

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

                                                                                                     c.OperationFilter<AcceptLanguageHeaderFilter>();
                                                                                                 });

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
            });
        }
    }
}
