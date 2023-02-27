using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserClaimController
{
	public record UserClaimGetAllOutput
	{
		public IEnumerable<UserClaimDto> UserClaims { get; set; }

		public UserClaimGetAllOutput(IEnumerable<UserClaimDto> userClaims)
		{
			UserClaims = userClaims;
		}
	}
}
