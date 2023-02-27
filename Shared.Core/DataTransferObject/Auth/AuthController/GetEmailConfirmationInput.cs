using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Auth.AuthController
{
	public record GetEmailConfirmationInput
	{
		[Required] public string Email { get; set; }
	}
}
