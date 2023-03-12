using Microsoft.AspNetCore.Identity;
using System;

namespace Shared.Core.Entities.Identity
{
	public partial class UserRole : IdentityUserRole<Guid>, IBaseEntity<Guid>
	{
		new public Guid Id { get; set; }
	}
}
