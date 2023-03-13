using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Shared.Core.Attributes;
using Shared.Core.Configuration;
using Shared.Core.Extensions;
using Shared.Infrastructure.Data;

namespace API.Configuration
{
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
                Port = uint.TryParse(configuration.GetFromEnvironmentVariable("DB", "PORT"), out uint p) ? p : 3306,
            }.ConnectionString;

            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            using (var scope = services.BuildServiceProvider())
            {
                var identityContext = scope.GetRequiredService<IdentityContext>();
                identityContext.Database.Migrate();
            }
        }
    }
}
