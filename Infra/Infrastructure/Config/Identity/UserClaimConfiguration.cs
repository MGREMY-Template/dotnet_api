namespace Infrastructure.Config.Identity;

using Domain.Entities.Identity;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(UserClaim)}");

        var claims = new List<UserClaim>();

        var claimNames = typeof(Domain.Constants.ClaimDefinition).GetAllPublicConstantValues<string>();

        for (var i = 0; i < claimNames.Length; i++)
        {
            claims.Add(new UserClaim { Id = i + 1, UserId = Guid.Parse("d8645da5-5583-4287-9e20-51f8dd6796bd"), ClaimType = claimNames[i], ClaimValue = "1" });
        }

        _ = builder.HasData(claims);
    }
}
