using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities.Identity;

namespace Shared.Infrastructure.Config.Identity
{
	public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
	{
		public void Configure(EntityTypeBuilder<RoleClaim> builder)
		{
			builder.ToTable($"__Identity_{nameof(RoleClaim)}");

			builder.Property(rc => rc.ClaimType)
				.IsRequired();
			builder.Property(rc => rc.ClaimValue)
				.IsRequired();
		}
	}
}
