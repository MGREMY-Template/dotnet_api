using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Extensions;
using Shared.Core.Interface.Repository.Identity;
using Shared.Core.Queries.Identity.User;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Application.Handlers.Identity.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IStringLocalizer _globalStringLocalizer;

        public GetUserByIdQueryHandler(
            IUserRepository repository,
            IMapper mapper,
            ILogger<GetUserByIdQueryHandler> logger,
            IStringLocalizer<Core.Resources.Services.Identity.UserService> stringLocalizer)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _globalStringLocalizer = stringLocalizer;
        }

        public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Result.Create(await _repository.GetByKeyAsync(request.Id, cancellationToken), 200, 404, _globalStringLocalizer.GetString(Core.Resources.Services.Identity.UserServiceConstants.UserFindNotFound))
                .Map(_mapper.Map<UserDto>);
        }
    }
}
