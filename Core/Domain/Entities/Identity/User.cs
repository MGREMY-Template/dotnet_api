namespace Domain.Entities.Identity;

using Domain.Entities;
using Domain.Entities.Application;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

public partial class User : IdentityUser<Guid>, IBaseEntity<Guid>
{
    public override Guid Id { get; set; }

    public virtual IEnumerable<AppFile> Files { get; set; }
}
