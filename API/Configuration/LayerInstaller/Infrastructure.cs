using Domain.Attribute;
using Domain.Configuration;
using Domain.Option;
using Infrastructure.Factory;
using Infrastructure.Data;

namespace API.Configuration.LayerInstaller;

[ServiceInstallerOrder(1)]
public class Infrastructure : IServiceInstaller
{
    public WebApplicationBuilder Configure(WebApplicationBuilder builder)
    {
        var databaseOptions = builder.Configuration
            .GetSection(DatabaseOptions.Key)
            .Get<DatabaseOptions>();

        builder.Services.AddDbContext<ApplicationContext>(options =>
            DbOptionsFactory.GetDbFactory(databaseOptions).GetDbOptions(options)
        );

        return builder;
    }

    public WebApplication Install(WebApplication application)
    {
        return application;
    }
}