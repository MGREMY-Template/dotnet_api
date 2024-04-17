namespace Domain.Option;

public class DatabaseOptions
{
    public const string Key = "Database";

    public DatabaseType Type { get; set; }
    public List<DatabaseOption> Data { get; set; } = [];
}

public class DatabaseOption
{
    public DatabaseType? Type { get; set; }
    public string? Server { get; set; }
    public int Port { get; set; } = 0;
    public string? Database { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}