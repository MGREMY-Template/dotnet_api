using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Core.Attributes;
using Shared.Core.Configuration;
using System.Text;

namespace API.Configuration
{
	[ConfigOrder(2)]
	public sealed partial class LayerInstaller_Authentication : IServiceInstaller
	{
		public void Configure(IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(opt =>
			{
				opt.SaveToken = true;

				opt.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = configuration["Jwt:Issuer"],
					ValidAudience = configuration["Jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
				};
			});
		}
	}
}
