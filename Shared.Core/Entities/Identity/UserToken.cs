using Microsoft.AspNetCore.Identity;
using System;

namespace Shared.Core.Entities.Identity
{
    public partial class UserToken : IdentityUserToken<Guid>, IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
