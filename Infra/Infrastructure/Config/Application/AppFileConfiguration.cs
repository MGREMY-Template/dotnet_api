namespace Infrastructure.Config.Application;

using Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppFileConfiguration : IEntityTypeConfiguration<AppFile>
{
    public void Configure(EntityTypeBuilder<AppFile> builder)
    {
        _ = builder.ToTable($"{nameof(AppFile)}");

        _ = builder.HasKey(x => x.Id);

        _ = builder.Ignore(x => x.Content);
        _ = builder.Ignore(x => x.CreationUser);

        _ = builder.HasOne(x => x.CreationUser)
            .WithMany(y => y.Files)
            .HasForeignKey(x => x.UserId);

        _ = builder.Property(x => x.CreationDate)
            .IsRequired()
            .ValueGeneratedOnAdd();
        _ = builder.Property(x => x.MimeType)
            .IsRequired()
            .HasMaxLength(25);
        _ = builder.Property(x => x.Size)
            .IsRequired();
    }
}
