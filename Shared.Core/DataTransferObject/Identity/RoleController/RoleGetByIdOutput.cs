namespace Shared.Core.DataTransferObject.Identity.RoleController
{
	public record RoleGetByIdOutput
	{
		public RoleDto Role { get; set; }

		public RoleGetByIdOutput(RoleDto role)
		{
			Role = role;
		}
	}
}
