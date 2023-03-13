namespace Shared.Core.Interface.Repository.Identity;

using Shared.Core.Entities.Identity;
using System;

public interface IUserRepository : IGenericRepository<User, Guid>
{
}
