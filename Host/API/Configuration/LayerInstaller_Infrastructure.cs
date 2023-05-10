namespace API.Configuration;

using Domain.Configuration;
using Domain.Extensions;
using Domain.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Domain.Attributes;
using Domain.Entities.Identity;
using System;
using Microsoft.AspNetCore.Identity;
using System.Linq;

[ConfigOrder(1)]
public class LayerInstaller_Infrastructure : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = new MySqlConnectionStringBuilder
        {
            Server = configuration.GetFromEnvironmentVariable("DB", "ADDR") ?? "localhost",
            Database = configuration.GetFromEnvironmentVariable("DB", "DB") ?? "DotNet-API",
            UserID = configuration.GetFromEnvironmentVariable("DB", "UID") ?? "user",
            Password = configuration.GetFromEnvironmentVariable("DB", "PWD") ?? "password",
            Port = uint.TryParse(configuration.GetFromEnvironmentVariable("DB", "PORT"), out var p) ? p : 3306,
        }.ConnectionString;

        _ = services.AddDbContext<IdentityContext>(options =>
        {
            _ = options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        using ServiceProvider scope = services.BuildServiceProvider();
        IdentityContext identityContext = scope.GetRequiredService<IdentityContext>();
        identityContext.Database.Migrate();

        if (identityContext.AppSettings.Find(Domain.Constants.AppSettingConstants.IS_INITIALIZED).Value.Equals("0"))
        {
            InitializeData(identityContext, configuration, scope.GetRequiredService<IPasswordHasher<User>>());
        }

        _ = services.AddScoped<IAppDbContext>(provider =>
        {
            return provider.GetService<IdentityContext>();
        });

        static void InitializeData(IdentityContext context, IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = configuration.GetFromEnvironmentVariable("INIT", "USER", "USERNAME") ?? "admin",
                NormalizedUserName = configuration.GetFromEnvironmentVariable("INIT", "USER", "USERNAME")?.ToUpper()?.Normalize() ?? "admin".Normalize(),
                Email = configuration.GetFromEnvironmentVariable("INIT", "USER", "EMAIL") ?? "admin@admin.admin",
                NormalizedEmail = configuration.GetFromEnvironmentVariable("INIT", "USER", "EMAIL")?.ToUpper()?.Normalize() ?? "admin@admin.admin".Normalize(),
                EmailConfirmed = true,
            };

            user.PasswordHash = passwordHasher.HashPassword(user, configuration.GetFromEnvironmentVariable("INIT", "USER", "PASSWORD") ?? "password");

            context.Users.Add(user);

            foreach (var claim in typeof(Domain.Constants.ClaimDefinition).GetAllPublicConstantValues<string>())
            {
                context.UserClaims.Add(new UserClaim { UserId = user.Id, ClaimType = claim, ClaimValue = "1" });
            }

            context.UserRoles.Add(new UserRole { RoleId = context.Roles.First(x => x.Name.Equals(Domain.Constants.RoleDefinition.ADMIN)).Id, UserId = user.Id });

            context.AppSettings.Find(Domain.Constants.AppSettingConstants.IS_INITIALIZED).Value = "1";

            context.SaveChanges();
        }
    }

    public void Install(IApplicationBuilder applicationBuilder)
    {
    }
}
