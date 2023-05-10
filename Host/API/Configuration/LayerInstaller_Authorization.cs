namespace API.Configuration;

using Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Attributes;
using Domain.Extensions;
using Domain.Constants;

[ConfigOrder(2)]
public class LayerInstaller_Authorization : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddAuthorization(opt =>
        {
            var claims = typeof(ClaimDefinition).GetAllPublicConstantValues<string>();

            foreach (var claim in claims)
            {
                opt.AddPolicy(claim, p =>
                {
                    p.RequireClaim(claim, "1");
                });
            }
        });
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
        _ = applicationBuilder.UseAuthorization();
    }
}
