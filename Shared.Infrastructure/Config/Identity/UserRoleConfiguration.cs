﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities.Identity;

namespace Shared.Infrastructure.Config.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable($"__Identity_{nameof(UserRole)}");

            builder.HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();

            builder.HasKey(x => x.Id);
        }
    }
}
