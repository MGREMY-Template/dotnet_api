namespace Infrastructure.Config;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppSettingConfiguration : IEntityTypeConfiguration<AppSetting>
{
    public void Configure(EntityTypeBuilder<AppSetting> builder)
    {
        _ = builder.ToTable($"__App_{nameof(AppSetting)}");

        _ = builder.HasKey(x => x.Name);

        _ = builder.HasData(new AppSetting { Name = Domain.Constants.AppSettingConstants.IS_INITIALIZED, Value = "0" });
    }
}
