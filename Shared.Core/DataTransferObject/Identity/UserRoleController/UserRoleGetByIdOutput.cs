namespace Shared.Core.DataTransferObject.Identity.UserRoleController
{
	public record UserRoleGetByIdOutput
	{
		public UserRoleDto UserRole { get; set; }

		public UserRoleGetByIdOutput(UserRoleDto userRole)
		{
			UserRole = userRole;
		}
	}
}
