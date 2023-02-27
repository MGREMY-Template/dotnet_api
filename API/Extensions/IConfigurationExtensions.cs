using Microsoft.Extensions.Configuration;

namespace API.Extensions
{
	public static class IConfigurationExtensions
	{
		public static string GetFromEnvironmentVariable(
			this IConfiguration configuration,
			params string[] keys)
		{
			return configuration[string.Join(":", "APP_CFG", keys)];
		}
	}
}
