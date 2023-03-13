namespace Shared.Infrastructure.Config.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities.Identity;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(UserClaim)}");

        _ = builder.HasIndex(x => new { x.UserId, x.ClaimType }).IsUnique();

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(uc => uc.ClaimType)
            .IsRequired();
        _ = builder.Property(uc => uc.ClaimValue)
            .IsRequired();
    }
}
