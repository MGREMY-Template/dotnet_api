using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Auth.AuthController.Input
{
    public record SignInInput
    {
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}
