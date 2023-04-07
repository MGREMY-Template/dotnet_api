namespace Infrastructure.Config.Identity;

using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(Role)}");
    }
}
