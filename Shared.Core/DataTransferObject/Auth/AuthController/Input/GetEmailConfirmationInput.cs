using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Auth.AuthController.Input
{
    public record GetEmailConfirmationInput
    {
        [Required] public string Email { get; set; }
    }
}
