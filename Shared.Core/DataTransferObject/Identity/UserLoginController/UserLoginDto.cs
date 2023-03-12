using System;

namespace Shared.Core.DataTransferObject.Identity.UserLoginController
{
	public record UserLoginDto
	{
		public Guid Id { get; set; }
		public string LoginProvider { get; set; }
		public string ProviderKey { get; set; }
		public Guid UserId { get; set; }

		public UserLoginDto(Guid id, string loginProvider, string providerKey, Guid userId)
		{
			Id = id;
			LoginProvider = loginProvider;
			ProviderKey = providerKey;
			UserId = userId;
		}
	}
}
