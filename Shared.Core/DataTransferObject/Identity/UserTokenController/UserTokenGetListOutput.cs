using System.Collections.Generic;

namespace Shared.Core.DataTransferObject.Identity.UserTokenController
{
	public record UserTokenGetListOutput
	{
		public IEnumerable<UserTokenDto> UserTokens { get; set; }

		public UserTokenGetListOutput(IEnumerable<UserTokenDto> userTokens)
		{
			UserTokens = userTokens;
		}
	}
}
