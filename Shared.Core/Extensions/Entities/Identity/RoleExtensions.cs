using Shared.Core.DataTransferObject.Identity.RoleController;
using Shared.Core.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Core.Extensions.Entities.Identity
{
	public static class RoleExtensions
	{
		public static RoleDto ToDto(
			this Role value)
		{
			if (value is not null)
			{
				return new(value.Id, value.Name);
			}

			return default;
		}

		public static IEnumerable<RoleDto> ToDto(
			this IEnumerable<Role> value)
		{
			if (value is not null)
			{
				return value.Select(x => x.ToDto());
			}

			return default;
		}
	}
}
