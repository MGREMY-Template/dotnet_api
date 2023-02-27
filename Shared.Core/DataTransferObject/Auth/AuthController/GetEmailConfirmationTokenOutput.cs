namespace Shared.Core.DataTransferObject.Auth.AuthController
{
	public record GetEmailConfirmationTokenOutput
	{
		public string Token { get; set; }
	}
}
