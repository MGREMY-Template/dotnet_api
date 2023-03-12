using Microsoft.AspNetCore.Identity;
using System;

namespace Shared.Core.Entities.Identity
{
	public partial class RoleClaim : IdentityRoleClaim<Guid>, IBaseEntity<Guid>
	{
		new public Guid Id { get; set; }
	}
}
