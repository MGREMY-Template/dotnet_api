namespace Shared.Core.Extensions;

using Microsoft.Extensions.Configuration;
using System.Linq;

public static class IConfigurationExtensions
{
    public static string GetFromEnvironmentVariable(
        this IConfiguration configuration,
        params string[] keys) => configuration[string.Join(":", keys.Prepend("APP_CFG"))];
}
