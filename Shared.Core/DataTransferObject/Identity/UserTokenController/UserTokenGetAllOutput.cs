using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserTokenController
{
	public record UserTokenGetAllOutput
	{
		public IEnumerable<UserTokenDto> UserTokens { get; set; }

		public UserTokenGetAllOutput(IEnumerable<UserTokenDto> userTokens)
		{
			UserTokens = userTokens;
		}
	}
}
