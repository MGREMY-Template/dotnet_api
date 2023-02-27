using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Core.Extensions.Entities.Identity
{
	public static class UserExtensions
	{
		public static UserDto ToDto(
			this User value)
		{
			if (value is not null)
			{
				return new(value.Id, value.UserName, value.Email);
			}

			return default;
		}

		public static IEnumerable<UserDto> ToDto(
			this IEnumerable<User> value)
		{
			if (value is not null)
			{
				return value.Select(x => x.ToDto());
			}

			return default;
		}
	}
}
