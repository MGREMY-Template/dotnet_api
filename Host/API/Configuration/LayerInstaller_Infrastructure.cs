namespace API.Configuration;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Shared.Core.Attributes;
using Shared.Core.Configuration;
using Shared.Core.Extensions;
using Shared.Core.Interface;
using Shared.Infrastructure.Data;

[ConfigOrder(0)]
public class LayerInstaller_Infrastructure : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = new MySqlConnectionStringBuilder
        {
            Server = configuration.GetFromEnvironmentVariable("DB", "ADDR") ?? "localhost",
            Database = configuration.GetFromEnvironmentVariable("DB", "DB") ?? "DotNet-API",
            UserID = configuration.GetFromEnvironmentVariable("DB", "UID") ?? "user",
            Password = configuration.GetFromEnvironmentVariable("DB", "PWD") ?? "password",
            Port = uint.TryParse(configuration.GetFromEnvironmentVariable("DB", "PORT"), out var p) ? p : 3306,
        }.ConnectionString;

        _ = services.AddDbContext<IdentityContext>(options =>
        {
            _ = options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        using ServiceProvider scope = services.BuildServiceProvider();
        IdentityContext identityContext = scope.GetRequiredService<IdentityContext>();
        identityContext.Database.Migrate();

        _ = services.AddScoped<IAppDbContext>(provider =>
        {
            return provider.GetService<IdentityContext>();
        });
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
    }
}
