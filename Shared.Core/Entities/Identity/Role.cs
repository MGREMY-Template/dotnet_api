namespace Shared.Core.Entities.Identity;

using Microsoft.AspNetCore.Identity;
using System;

public partial class Role : IdentityRole<Guid>, IBaseEntity<Guid>
{
    public override Guid Id { get; set; }
}
