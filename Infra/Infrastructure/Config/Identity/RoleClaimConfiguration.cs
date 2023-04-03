namespace Infrastructure.Config.Identity;

using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(RoleClaim)}");

        _ = builder.HasKey(x => x.Id);

        _ = builder.HasIndex(x => new { x.RoleId, x.ClaimType }).IsUnique();

        _ = builder.Property(rc => rc.ClaimType)
            .IsRequired();
        _ = builder.Property(rc => rc.ClaimValue)
            .IsRequired();
    }
}
