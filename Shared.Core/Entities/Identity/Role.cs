using Microsoft.AspNetCore.Identity;
using System;

namespace Shared.Core.Entities.Identity
{
	public partial class Role : IdentityRole<Guid>, IBaseEntity<Guid>
	{
		override public Guid Id { get; set; }
	}
}
