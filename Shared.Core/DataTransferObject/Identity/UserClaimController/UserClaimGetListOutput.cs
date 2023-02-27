using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserClaimController
{
	public record UserClaimGetListOutput
	{
		public IEnumerable<UserClaimDto> UserClaims { get; set; }

		public UserClaimGetListOutput(IEnumerable<UserClaimDto> userClaims)
		{
			UserClaims = userClaims;
		}
	}
}
