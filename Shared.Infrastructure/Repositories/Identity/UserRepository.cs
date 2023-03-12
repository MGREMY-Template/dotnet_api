using Shared.Core.Entities.Identity;
using Shared.Core.Interface.Repository.Identity;
using Shared.Infrastructure.Data;
using System;

namespace Shared.Infrastructure.Repositories.Identity
{
    public class UserRepository : GenericRepository<User, Guid>, IUserRepository
    {
        public UserRepository(IdentityContext context) : base(context) { }
    }
}
