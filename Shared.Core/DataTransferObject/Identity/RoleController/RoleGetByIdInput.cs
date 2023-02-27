using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Identity.RoleController
{
	public record RoleGetByIdInput
	{
		[Required] public int Id { get; set; }
	}
}
