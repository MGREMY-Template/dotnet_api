namespace Shared.Core.DataTransferObject.Identity.UserTokenController
{
	public record UserTokenDto
	{
		public int UserId { get; set; }
		public string LoginProvider { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }

		public UserTokenDto(int userId, string loginProvider, string name, string value)
		{
			UserId = userId;
			LoginProvider = loginProvider;
			Name = name;
			Value = value;
		}
	}
}
