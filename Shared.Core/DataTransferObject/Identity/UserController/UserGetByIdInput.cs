using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Identity.UserController
{
	public record UserGetByIdInput
	{
		[Required] public Guid Id { get; set; }
	}
}
