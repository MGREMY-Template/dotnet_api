namespace Infrastructure.Config.Identity;

using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(UserClaim)}");
    }
}
