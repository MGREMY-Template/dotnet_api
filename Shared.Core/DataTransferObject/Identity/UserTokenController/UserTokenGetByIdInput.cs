using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Identity.UserTokenController
{
	public record UserTokenGetByIdInput
	{
		[Required] public Guid UserId { get; set; }
		[Required] public string LoginProvider { get; set; }
		[Required] public string Name { get; set; }
	}
}
