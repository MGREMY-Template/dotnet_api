using Shared.Core.DataTransferObject.Identity.UserTokenController;
using Shared.Core.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Core.Extensions.Entities.Identity
{
	public static class UserTokenExtensions
	{
		public static UserTokenDto ToDto(
			this UserToken value)
		{
			if (value is not null)
			{
				return new(value.UserId, value.LoginProvider, value.Name, value.Value);
			}

			return default;
		}

		public static IEnumerable<UserTokenDto> ToDto(
			this IEnumerable<UserToken> value)
		{
			if (value is not null)
			{
				return value.Select(x => x.ToDto());
			}

			return default;
		}
	}
}
