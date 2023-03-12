using System;

namespace Shared.Core.DataTransferObject.Identity.UserClaimController
{
	public record UserClaimDto
	{
		public Guid UserId { get; set; }
		public string ClaimType { get; set; }
		public string ClaimValue { get; set; }

		public UserClaimDto(Guid userId, string claimType, string claimValue)
		{
			UserId = userId;
			ClaimType = claimType;
			ClaimValue = claimValue;
		}
	}
}
