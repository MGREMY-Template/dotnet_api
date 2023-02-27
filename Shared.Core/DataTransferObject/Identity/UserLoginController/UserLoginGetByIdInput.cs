using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Identity.UserLoginController
{
	public record UserLoginGetByIdInput
	{
		[Required] public string LoginProvider { get; set; }
		[Required] public string ProviderKey { get; set; }
	}
}
