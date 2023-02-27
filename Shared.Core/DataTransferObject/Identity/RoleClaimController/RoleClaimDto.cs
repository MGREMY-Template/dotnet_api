namespace Shared.Core.DataTransferObject.Identity.RoleClaimController
{
	public record RoleClaimDto
	{
		public int Id { get; set; }
		public int RoleId { get; set; }
		public string ClaimType { get; set; }
		public string ClaimValue { get; set; }

		public RoleClaimDto(int id, int roleId, string claimType, string claimValue)
		{
			Id = id;
			RoleId = roleId;
			ClaimType = claimType;
			ClaimValue = claimValue;
		}
	}
}
