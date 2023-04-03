namespace Domain.Entities.Identity;

using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;

public partial class Role : IdentityRole<Guid>, IBaseEntity<Guid>
{
    public override Guid Id { get; set; }
}
