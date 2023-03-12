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
        private readonly IUserRepository _userRepository;

        public UserService(
            IUnitOfWork<User, Guid> unitOfWork,
            IMapper mapper,
            ILogger<UserService> logger,
            IStringLocalizer<Core.Resources.Global> globalStringLocalizer,
            IUserRepository userRepository) : base(unitOfWork, mapper, logger, globalStringLocalizer)
        {
            _userRepository = userRepository;
        }
    }
}
