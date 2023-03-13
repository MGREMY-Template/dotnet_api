namespace Shared.Infrastructure.Repositories.Identity;

using Shared.Core.Entities.Identity;
using Shared.Core.Interface.Repository.Identity;
using Shared.Infrastructure.Data;
using System;

public class UserRepository : GenericRepository<User, Guid>, IUserRepository
{
    public UserRepository(IdentityContext context) : base(context) { }
}
