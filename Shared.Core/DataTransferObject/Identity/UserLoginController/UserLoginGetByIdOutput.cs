namespace Shared.Core.DataTransferObject.Identity.UserLoginController
{
	public record UserLoginGetByIdOutput
	{
		public UserLoginDto UserLogin { get; set; }

		public UserLoginGetByIdOutput(UserLoginDto userLogin)
		{
			UserLogin = userLogin;
		}
	}
}
