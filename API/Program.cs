using Domain.Configuration;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddEnvironmentVariables();

        builder.Configure(typeof(API.Marker).Assembly,
            typeof(Domain.Marker).Assembly,
            typeof(Application.Marker).Assembly,
            typeof(Infrastructure.Marker).Assembly);

        var app = builder.Build();

        app.Install(typeof(API.Marker).Assembly,
            typeof(Domain.Marker).Assembly,
            typeof(Application.Marker).Assembly,
            typeof(Infrastructure.Marker).Assembly);

        app.MapControllers();

        app.Run();
    }
}