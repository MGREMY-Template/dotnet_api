namespace Shared.Infrastructure.Config.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities.Identity;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(User)}");

        _ = builder.HasIndex(x => new { x.NormalizedEmail }).IsUnique();
        _ = builder.HasIndex(x => new { x.NormalizedUserName }).IsUnique();

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(u => u.Email)
            .IsRequired();
        _ = builder.Property(u => u.NormalizedEmail)
            .IsRequired();
        _ = builder.Property(u => u.PasswordHash)
            .IsRequired();
    }
}
