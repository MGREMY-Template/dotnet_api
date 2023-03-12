using Microsoft.AspNetCore.Identity;
using System;

namespace Shared.Core.Entities.Identity
{
    public partial class UserLogin : IdentityUserLogin<Guid>, IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
