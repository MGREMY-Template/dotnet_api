namespace Infrastructure.Config.Identity;

using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(Role)}");

        _ = builder.HasData(new Role { Id = Guid.Parse("88071f9d-4fa7-4618-9d04-6d430e121e73"), Name = Domain.Constants.RoleDefinition.ADMIN, NormalizedName = Domain.Constants.RoleDefinition.ADMIN.ToUpper().Normalize() });
    }
}
