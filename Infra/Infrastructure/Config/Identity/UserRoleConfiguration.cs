namespace Infrastructure.Config.Identity;

using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(UserRole)}");

        _ = builder.HasData(new UserRole { RoleId = Guid.Parse("88071f9d-4fa7-4618-9d04-6d430e121e73"), UserId = Guid.Parse("d8645da5-5583-4287-9e20-51f8dd6796bd") });
    }
}
