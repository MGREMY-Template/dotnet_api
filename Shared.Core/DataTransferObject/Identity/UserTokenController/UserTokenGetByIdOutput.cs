namespace Shared.Core.DataTransferObject.Identity.UserTokenController
{
	public record UserTokenGetByIdOutput
	{
		public UserTokenDto UserToken { get; set; }

		public UserTokenGetByIdOutput(UserTokenDto userToken)
		{
			UserToken = userToken;
		}
	}
}
