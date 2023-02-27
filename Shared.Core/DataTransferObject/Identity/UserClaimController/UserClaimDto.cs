namespace Shared.Core.DataTransferObject.Identity.UserClaimController
{
	public record UserClaimDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string ClaimType { get; set; }
		public string ClaimValue { get; set; }

		public UserClaimDto(int id, int userId, string claimType, string claimValue)
		{
			Id = id;
			UserId = userId;
			ClaimType = claimType;
			ClaimValue = claimValue;
		}
	}
}
