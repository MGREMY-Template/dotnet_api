namespace Shared.Core.DataTransferObject.Identity.UserRoleController
{
	public record UserRoleDto
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }

		public UserRoleDto(int userid, int roleId)
		{
			UserId = userid;
			RoleId = roleId;
		}
	}
}
