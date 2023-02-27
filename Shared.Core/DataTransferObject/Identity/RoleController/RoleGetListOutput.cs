using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.RoleController
{
	public record RoleGetListOutput
	{
		public IEnumerable<RoleDto> Roles { get; set; }

		public RoleGetListOutput(IEnumerable<RoleDto> roles)
		{
			Roles = roles;
		}
	}
}
