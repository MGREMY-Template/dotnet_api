using System;

namespace Shared.Core.DataTransferObject.Identity.UserClaimController
{
	public record UserClaimDto
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public string ClaimType { get; set; }
		public string ClaimValue { get; set; }

		public UserClaimDto(Guid id, Guid userId, string claimType, string claimValue)
		{
			Id = id;
			UserId = userId;
			ClaimType = claimType;
			ClaimValue = claimValue;
		}
	}
}
