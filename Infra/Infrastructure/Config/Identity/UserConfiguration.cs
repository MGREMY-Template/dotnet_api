namespace Infrastructure.Config.Identity;

using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        _ = builder.ToTable($"__Identity_{nameof(User)}");

        _ = builder.HasData(new User
        {
            Id = Guid.Parse("d8645da5-5583-4287-9e20-51f8dd6796bd"),
            UserName = "admin",
            NormalizedUserName = "admin".ToUpper()?.Normalize(),
            Email = "admin@admin.admin",
            NormalizedEmail = "admin@admin.admin".ToUpper().Normalize(),
            PasswordHash = "AQAAAAIAAYagAAAAEDxk5EthOl3tW2BdXKdmAoxUUAvai68jo1xp7mb1Id0qfBcFB1N+vvHisZ8/TIs9Cw==",
            EmailConfirmed = true,
        });
    }
}
