using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserLoginController
{
	public record UserLoginGetAllOutput
	{
		public IEnumerable<UserLoginDto> UserLogins { get; set; }

		public UserLoginGetAllOutput(IEnumerable<UserLoginDto> userLogins)
		{
			UserLogins = userLogins;
		}
	}
}
