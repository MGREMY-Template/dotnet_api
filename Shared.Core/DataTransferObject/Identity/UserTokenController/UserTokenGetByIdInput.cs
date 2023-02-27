using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Identity.UserTokenController
{
	public record UserTokenGetByIdInput
	{
		[Required] public int UserId { get; set; }
		[Required] public string LoginProvider { get; set; }
		[Required] public string Name { get; set; }
	}
}
