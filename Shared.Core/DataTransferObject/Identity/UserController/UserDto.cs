namespace Shared.Core.DataTransferObject.Identity.UserController
{
	public record UserDto
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }

		public UserDto(int id, string userName, string email)
		{
			Id = id;
			UserName = userName;
			Email = email;
		}
	}
}
