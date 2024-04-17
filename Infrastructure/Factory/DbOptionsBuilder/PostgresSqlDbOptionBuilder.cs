using Domain.Option;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Factory.DbOptionsBuilder;

public class PostgresSqlDbOptionBuilder(DatabaseOption options) : IDbOptionBuilder
{
    public DbContextOptionsBuilder GetDbOptions(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new NpgsqlConnectionStringBuilder
        {
            Host = options.Server,
            Database = options.Database,
            Username = options.Username,
            Password = options.Password,
            Port = options.Port,
        }.ConnectionString;

        optionsBuilder.UseNpgsql(
            connectionString,
            x =>
                x.MigrationsAssembly("PostgresSqlMigrations")
        );

        return optionsBuilder;
    }
}