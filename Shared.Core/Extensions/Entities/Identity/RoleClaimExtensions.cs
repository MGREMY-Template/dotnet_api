using Shared.Core.DataTransferObject.Identity.RoleClaimController;
using Shared.Core.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Core.Extensions.Entities.Identity
{
	public static class RoleClaimExtensions
	{
		public static RoleClaimDto ToDto(
			this RoleClaim value)
		{
			if (value is not null)
			{
				return new(value.Id, value.RoleId, value.ClaimType, value.ClaimValue);
			}

			return default;
		}

		public static IEnumerable<RoleClaimDto> ToDto(
			this IEnumerable<RoleClaim> value)
		{
			if (value is not null)
			{
				return value.Select(x => x.ToDto());
			}

			return default;
		}
	}
}
