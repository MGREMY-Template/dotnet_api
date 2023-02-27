using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.RoleClaimController
{
	public record RoleClaimGetAllOutput
	{
		public IEnumerable<RoleClaimDto> RoleClaims { get; set; }

		public RoleClaimGetAllOutput(IEnumerable<RoleClaimDto> roleClaims)
		{
			RoleClaims = roleClaims;
		}
	}
}
