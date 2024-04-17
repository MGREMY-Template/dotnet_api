using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Factory.DbOptionsBuilder;

public interface IDbOptionBuilder
{
    public DbContextOptionsBuilder GetDbOptions(DbContextOptionsBuilder optionsBuilder);
}