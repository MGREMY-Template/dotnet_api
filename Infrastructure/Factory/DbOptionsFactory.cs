using Domain.Option;
using Infrastructure.Factory.DbOptionsBuilder;

namespace Infrastructure.Factory;

public static class DbOptionsFactory
{
    public static IDbOptionBuilder GetDbFactory(DatabaseOptions? options)
    {
        ArgumentNullException.ThrowIfNull(options);

        return options.Type switch
        {
            DatabaseType.MariaDb => new MariaDbOptionBuilder(options: GetOption(options)),
            DatabaseType.MySql => new MySqlDbOptionBuilder(options: GetOption(options)),
            DatabaseType.SqlServer => new SqlServerDbOptionBuilder(options: GetOption(options)),
            DatabaseType.PostgresSql => new PostgresSqlDbOptionBuilder(options: GetOption(options)),
            DatabaseType.SqLite => new SqLiteDbOptionBuilder(options: GetOption(options)),
            _ => throw new ArgumentOutOfRangeException()
        };

        static DatabaseOption GetOption(DatabaseOptions options) =>
            options.Data.Single(x => x.Type == options.Type);
    }
}