using Shared.Core.Entities.Identity;
using System;

namespace Shared.Core.Interface.Repository.Identity
{
    public interface IUserRepository : IGenericRepository<User, Guid>
    {
    }
}
