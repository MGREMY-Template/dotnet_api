namespace Shared.Core.DataTransferObject.Auth.AuthController.Input;

using System.ComponentModel.DataAnnotations;

public record ConfirmEmailInput
{
    [Required] public string Email { get; set; }
    [Required] public string Token { get; set; }
}
