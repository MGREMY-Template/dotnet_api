namespace Shared.Core.DataTransferObject.Identity.UserLoginController
{
	public record UserLoginDto
	{
		public string LoginProvider { get; set; }
		public string ProviderKey { get; set; }
		public int UserId { get; set; }

		public UserLoginDto(string loginProvider, string providerKey, int userId)
		{
			LoginProvider = loginProvider;
			ProviderKey = providerKey;
			UserId = userId;
		}
	}
}
