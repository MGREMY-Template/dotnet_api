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

        _ = builder.HasData(new Role { Id = Guid.NewGuid(), Name = Domain.Constants.RoleDefinition.ADMIN, NormalizedName = Domain.Constants.RoleDefinition.ADMIN.ToUpper().Normalize() });
    }
}
