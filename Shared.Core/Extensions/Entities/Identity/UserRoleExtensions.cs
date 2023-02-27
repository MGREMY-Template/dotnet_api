using Shared.Core.DataTransferObject.Identity.UserRoleController;
using Shared.Core.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Core.Extensions.Entities.Identity
{
	public static class UserRoleExtensions
	{
		public static UserRoleDto ToDto(
			this UserRole value)
		{
			if (value is not null)
			{
				return new(value.UserId, value.RoleId);
			}

			return default;
		}

		public static IEnumerable<UserRoleDto> ToDto(
			this IEnumerable<UserRole> value)
		{
			if (value is not null)
			{
				return value.Select(x => x.ToDto());
			}

			return default;
		}
	}
}
