namespace Infrastructure.Config.Identity;

using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(UserToken)}");
    }
}
