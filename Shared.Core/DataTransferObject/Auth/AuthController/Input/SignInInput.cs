namespace Shared.Core.DataTransferObject.Auth.AuthController.Input;

using System.ComponentModel.DataAnnotations;

public record SignInInput
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
