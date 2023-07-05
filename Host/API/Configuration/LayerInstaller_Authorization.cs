namespace API.Configuration;

using Domain.Attributes;
using Domain.Configuration;
using Domain.Constants;
using Domain.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                    _ = p.RequireClaim(claim, "1");
                });
            }
        });
    }

    public void Install(WebApplication applicationBuilder)
    {
        _ = applicationBuilder.UseAuthorization();
    }
}
