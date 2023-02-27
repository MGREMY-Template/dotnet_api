using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserController
{
	public record UserGetListOutput
	{
		public IEnumerable<UserDto> Users { get; set; }

		public UserGetListOutput(IEnumerable<UserDto> users)
		{
			Users = users;
		}
	}
}
