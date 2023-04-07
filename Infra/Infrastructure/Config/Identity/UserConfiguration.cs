namespace Infrastructure.Config.Identity;

using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(User)}");
    }
}
