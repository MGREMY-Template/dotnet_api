namespace Domain.DataTransferObject.Auth.AuthController.Output;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record GetEmailConfirmationTokenOutput
{
    [Required, DisplayName("Token")] public string Token { get; set; }
}
