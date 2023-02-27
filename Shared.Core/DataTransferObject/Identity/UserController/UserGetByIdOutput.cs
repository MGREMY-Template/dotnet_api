namespace Shared.Core.DataTransferObject.Identity.UserController
{
	public record UserGetByIdOutput
	{
		public UserDto User { get; set; }

		public UserGetByIdOutput(UserDto user)
		{
			User = user;
		}
	}
}
