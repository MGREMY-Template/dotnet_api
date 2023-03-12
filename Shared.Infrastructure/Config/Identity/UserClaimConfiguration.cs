﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities.Identity;

namespace Shared.Infrastructure.Config.Identity
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable($"__Identity_{nameof(UserClaim)}");

            builder.HasIndex(x => new { x.UserId, x.ClaimType }).IsUnique();

            builder.HasKey(x => x.Id);

            builder.Property(uc => uc.ClaimType)
                .IsRequired();
            builder.Property(uc => uc.ClaimValue)
                .IsRequired();
        }
    }
}
