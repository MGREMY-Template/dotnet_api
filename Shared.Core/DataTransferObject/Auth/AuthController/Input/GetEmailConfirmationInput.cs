namespace Shared.Core.DataTransferObject.Auth.AuthController.Input;

using System.ComponentModel.DataAnnotations;

public record GetEmailConfirmationInput
{
    [Required] public string Email { get; set; }
}
