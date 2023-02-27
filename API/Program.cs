using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Core.Configuration;
using System.Linq;

namespace API.Configuration
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Configuration.AddEnvironmentVariables(prefix: "APP_CFG");

			builder.Services
				.Configure(
					builder.Configuration,
					typeof(Program).Assembly);

			// Add services to the container
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();

			var app = builder.Build();

			var localizationOptions = new RequestLocalizationOptions()
				.SetDefaultCulture(ServiceInstaller_Swagger.AcceptedLanguages.Keys.FirstOrDefault())
				.AddSupportedCultures(ServiceInstaller_Swagger.AcceptedLanguages.Keys.ToArray())
				.AddSupportedUICultures(ServiceInstaller_Swagger.AcceptedLanguages.Keys.ToArray());
			localizationOptions.ApplyCurrentCultureToResponseHeaders = true;

			app.UseRequestLocalization(localizationOptions);

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}