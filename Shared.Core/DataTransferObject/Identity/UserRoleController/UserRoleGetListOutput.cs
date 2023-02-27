using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserRoleController
{
	public record UserRoleGetListOutput
	{
		public IEnumerable<UserRoleDto> UserRoles { get; set; }

		public UserRoleGetListOutput(IEnumerable<UserRoleDto> userRoles)
		{
			UserRoles = userRoles;
		}
	}
}
