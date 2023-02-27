using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.RoleController
{
	public record RoleGetAllOutput
	{
		public IEnumerable<RoleDto> Roles { get; set; }

		public RoleGetAllOutput(IEnumerable<RoleDto> roles)
		{
			Roles = roles;
		}
	}
}
