using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Identity.UserRoleController
{
	public record UserRoleGetByIdInput
	{
		[Required] public int UserId { get; set; }
		[Required] public int RoleId { get; set; }
	}
}
