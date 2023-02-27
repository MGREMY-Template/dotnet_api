using System.ComponentModel.DataAnnotations;

namespace Shared.Core.DataTransferObject.Identity.UserController
{
	public record UserGetByIdInput
	{
		[Required] public int Id { get; set; }
	}
}
