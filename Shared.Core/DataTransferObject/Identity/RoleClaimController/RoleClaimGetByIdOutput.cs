namespace Shared.Core.DataTransferObject.Identity.RoleClaimController
{
	public record RoleClaimGetByIdOutput
	{
		public RoleClaimDto RoleClaim { get; set; }

		public RoleClaimGetByIdOutput(RoleClaimDto roleClaim)
		{
			RoleClaim = roleClaim;
		}
	}
}
