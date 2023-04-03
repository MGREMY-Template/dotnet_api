namespace Shared.Infrastructure.Config.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities.Identity;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(Role)}");

        _ = builder.HasIndex(x => new { x.Name }).IsUnique();

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(r => r.Name)
            .IsRequired();
        _ = builder.Property(r => r.NormalizedName)
            .IsRequired();
        _ = builder.Property(r => r.ConcurrencyStamp)
            .IsRequired();
    }
}
