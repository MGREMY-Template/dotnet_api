namespace API;

using Application;
using Domain;
using Domain.Configuration;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                typeof(Application.Marker).Assembly,
                typeof(Infrastructure.Marker).Assembly,
                typeof(Domain.Marker).Assembly);

        WebApplication app = builder.Build();

        app.Install(
            typeof(Program).Assembly,
            typeof(Application.Marker).Assembly,
            typeof(Infrastructure.Marker).Assembly,
            typeof(Domain.Marker).Assembly);

        app.MapControllers();

        app.Run();
    }
}
