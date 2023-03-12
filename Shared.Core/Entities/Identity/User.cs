using Microsoft.AspNetCore.Identity;
using System;

namespace Shared.Core.Entities.Identity
{
    public partial class User : IdentityUser<Guid>, IBaseEntity<Guid>
    {
        override public Guid Id { get; set; }
    }
}
