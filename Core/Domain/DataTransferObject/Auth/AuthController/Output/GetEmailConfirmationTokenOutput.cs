namespace Shared.Core.DataTransferObject.Auth.AuthController.Output;

public record GetEmailConfirmationTokenOutput
{
    public string Token { get; set; }
}
