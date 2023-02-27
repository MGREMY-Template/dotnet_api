namespace Shared.Core.DataTransferObject.Auth.AuthController
{
	public record SignUpOutput
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
	}
}
