using Shared.Core.DataTransferObject.Identity.UserClaimController;
using Shared.Core.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Core.Extensions.Entities.Identity
{
	public static class UserClaimExtensions
	{
		public static UserClaimDto ToDto(
			this UserClaim value)
		{
			if (value is not null)
			{
				return new(value.Id, value.UserId, value.ClaimType, value.ClaimValue);
			}

			return default;
		}

		public static IEnumerable<UserClaimDto> ToDto(
			this IEnumerable<UserClaim> value)
		{
			if (value is not null)
			{
				return value.Select(x => x.ToDto());
			}

			return default;
		}
	}
}
