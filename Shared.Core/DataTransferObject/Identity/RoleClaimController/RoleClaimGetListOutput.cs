using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.RoleClaimController
{
	public record RoleClaimGetListOutput
	{
		public IEnumerable<RoleClaimDto> RoleClaims { get; set; }

		public RoleClaimGetListOutput(IEnumerable<RoleClaimDto> roleClaims)
		{
			RoleClaims = roleClaims;
		}
	}
}
