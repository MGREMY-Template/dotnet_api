namespace API;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Configuration;

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

        WebApplication app = builder.Build();

        app.Install(
            typeof(Program).Assembly,
            typeof(Shared.Application.Marker).Assembly,
            typeof(Shared.Infrastructure.Marker).Assembly,
            typeof(Shared.Core.Marker).Assembly);

        app.MapControllers();

        app.Run();
    }
}
