using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserRoleController
{
	public record UserRoleGetAllOutput
	{
		public IEnumerable<UserRoleDto> UserRoles { get; set; }

		public UserRoleGetAllOutput(IEnumerable<UserRoleDto> userRoles)
		{
			UserRoles = userRoles;
		}
	}
}
