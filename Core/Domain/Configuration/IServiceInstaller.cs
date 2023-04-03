namespace Domain.Configuration;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public interface IServiceInstaller
{
    void Configure(IServiceCollection services, IConfiguration configuration);
    void Install(IApplicationBuilder applicationBuilder);
}
