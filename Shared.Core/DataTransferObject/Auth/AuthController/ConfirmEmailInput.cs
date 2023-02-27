using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Auth.AuthController
{
	public record ConfirmEmailInput
	{
		[Required] public string Email { get; set; }
		[Required] public string Token { get; set; }
	}
}
