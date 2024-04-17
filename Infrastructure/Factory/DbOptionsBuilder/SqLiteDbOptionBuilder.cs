using Domain.Option;
using Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Factory.DbOptionsBuilder;

public class SqLiteDbOptionBuilder(DatabaseOption options) : IDbOptionBuilder
{
    public DbContextOptionsBuilder GetDbOptions(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new SqliteConnectionStringBuilder
        {
            DataSource = options.Server,
            Password = options.Password,
            Mode = SqliteOpenMode.ReadWriteCreate,
        }.ConnectionString;

        optionsBuilder.UseSqlite(
            connectionString,
            x =>
                x.MigrationsAssembly("SqLiteMigrations")
        );

        return optionsBuilder;
    }
}