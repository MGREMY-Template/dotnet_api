using Shared.Core.DataTransferObject.Identity.UserLoginController;
using Shared.Core.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Core.Extensions.Entities.Identity
{
	public static class UserLoginExtensions
	{
		public static UserLoginDto ToDto(
			this UserLogin value)
		{
			if (value is not null)
			{
				return new(value.LoginProvider, value.ProviderKey, value.UserId);
			}

			return default;
		}

		public static IEnumerable<UserLoginDto> ToDto(
			this IEnumerable<UserLogin> value)
		{
			if (value is not null)
			{
				return value.Select(x => x.ToDto());
			}

			return default;
		}
	}
}
