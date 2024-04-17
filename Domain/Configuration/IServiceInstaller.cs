using Microsoft.AspNetCore.Builder;

namespace Domain.Configuration;

public interface IServiceInstaller
{
    WebApplicationBuilder Configure(WebApplicationBuilder builder);
    WebApplication Install(WebApplication application);
}