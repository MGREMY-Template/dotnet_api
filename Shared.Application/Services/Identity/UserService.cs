using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.Entities.Identity;
using Shared.Core.Interface.Repository;
using Shared.Core.Interface.Repository.Identity;
using Shared.Core.Interface.Service.Identity;
using System;

namespace Shared.Application.Services.Identity
{
    public class UserService : GenericService<User, Guid>, IUserService
    {
        public UserService(
            IUserRepository repository,
            IMapper mapper,
            ILogger<UserService> logger,
            IStringLocalizer<Core.Resources.Global> globalStringLocalizer) : base(repository, mapper, logger, globalStringLocalizer) {}
    }
}
