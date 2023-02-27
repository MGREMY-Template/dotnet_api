namespace Shared.Core.DataTransferObject.Identity.UserClaimController
{
	public record UserClaimGetByIdOutput
	{
		public UserClaimDto UserClaim { get; set; }

		public UserClaimGetByIdOutput(UserClaimDto userClaim)
		{
			UserClaim = userClaim;
		}
	}
}
