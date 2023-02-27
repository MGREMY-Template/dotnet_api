using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Identity.RoleClaimController
{
	public record RoleClaimGetByIdInput
	{
		[Required] public int Id { get; set; }
	}
}
