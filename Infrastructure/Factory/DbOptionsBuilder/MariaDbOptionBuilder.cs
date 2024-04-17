using Domain.Option;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Infrastructure.Factory.DbOptionsBuilder;

public class MariaDbOptionBuilder(DatabaseOption options) : IDbOptionBuilder
{
    public DbContextOptionsBuilder GetDbOptions(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new MySqlConnectionStringBuilder
        {
            Server = options.Server,
            Database = options.Database,
            UserID = options.Username,
            Password = options.Password,
            Port = (uint)options.Port,
        }.ConnectionString;

        optionsBuilder.UseMySql(
            connectionString: connectionString,
            ServerVersion.AutoDetect(connectionString),
            x =>
                x.MigrationsAssembly("MariaDbMigrations")
        );

        return optionsBuilder;
    }
}