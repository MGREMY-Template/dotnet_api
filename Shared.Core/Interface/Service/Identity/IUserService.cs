using Shared.Core.Entities.Identity;
using System;

namespace Shared.Core.Interface.Service.Identity
{
    public interface IUserService : IGenericService<User, Guid>
    {
    }
}
