using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities.Identity;

namespace Shared.Infrastructure.Config.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable($"__Identity_{nameof(Role)}");

            builder.HasIndex(x => new { x.Name }).IsUnique();

            builder.HasKey(x => x.Id);

            builder.Property(r => r.Name)
                .IsRequired();
            builder.Property(r => r.NormalizedName)
                .IsRequired();
            builder.Property(r => r.ConcurrencyStamp)
                .IsRequired();
        }
    }
}
