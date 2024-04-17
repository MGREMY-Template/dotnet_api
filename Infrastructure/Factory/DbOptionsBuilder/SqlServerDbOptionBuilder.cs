using Domain.Option;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Factory.DbOptionsBuilder;

public class SqlServerDbOptionBuilder(DatabaseOption options) : IDbOptionBuilder
{
    public DbContextOptionsBuilder GetDbOptions(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new SqlConnectionStringBuilder
        {
            DataSource = $"{options.Server},{options.Port}",
            InitialCatalog = options.Database,
            UserID = options.Username,
            Password = options.Password,
            Encrypt = false,
        }.ConnectionString;

        optionsBuilder.UseSqlServer(
            connectionString,
            x =>
                x.MigrationsAssembly("SqlServerMigrations")
        );

        return optionsBuilder;
    }
}