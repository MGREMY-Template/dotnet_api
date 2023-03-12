using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities.Identity;

namespace Shared.Infrastructure.Config.Identity
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable($"__Identity_{nameof(UserToken)}");

            builder.HasIndex(x => new { x.UserId, x.LoginProvider }).IsUnique();

            builder.Property(ut => ut.Value)
                .IsRequired();
        }
    }
}
