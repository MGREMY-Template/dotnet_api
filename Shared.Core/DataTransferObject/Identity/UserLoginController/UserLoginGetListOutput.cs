using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserLoginController
{
	public record UserLoginGetListOutput
	{
		public IEnumerable<UserLoginDto> UserLogins { get; set; }

		public UserLoginGetListOutput(IEnumerable<UserLoginDto> userLogins)
		{
			UserLogins = userLogins;
		}
	}
}
