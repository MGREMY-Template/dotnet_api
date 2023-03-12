using Microsoft.AspNetCore.Identity;
using System;

namespace Shared.Core.Entities.Identity
{
	public partial class Role : IdentityRole<Guid>, IBaseEntity<Guid>
	{
		new public Guid Id { get; set; }
	}
}
