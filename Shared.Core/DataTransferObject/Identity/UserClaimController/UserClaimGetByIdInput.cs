using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Identity.UserClaimController
{
	public record UserClaimGetByIdInput
	{
		[Required] public int Id { get; set; }
	}
}
