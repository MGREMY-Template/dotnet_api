using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Auth.AuthController.Input
{
    public record SignUpInput
    {
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}
