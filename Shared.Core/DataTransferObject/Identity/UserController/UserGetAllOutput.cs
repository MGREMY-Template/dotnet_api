using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserController
{
	public record UserGetAllOutput
	{
		public IEnumerable<UserDto> Users { get; set; }

		public UserGetAllOutput(IEnumerable<UserDto> users)
		{
			Users = users;
		}
	}
}
