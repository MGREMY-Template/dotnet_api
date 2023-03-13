using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Extensions;
using Shared.Core.Interface.Repository.Identity;
using Shared.Core.Queries.Identity.User;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Application.Handlers.Identity.User
{
    public class GetListUserQueryHandler : IRequestHandler<GetUserListQuery, Result<IEnumerable<UserDto>>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IStringLocalizer _globalStringLocalizer;

        public GetListUserQueryHandler(
            IUserRepository repository,
            IMapper mapper,
            ILogger<GetListUserQueryHandler> logger,
            IStringLocalizer<Core.Resources.Application.Global> globalStringLocalizer)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _globalStringLocalizer = globalStringLocalizer;
        }

        public async Task<Result<IEnumerable<UserDto>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return Result.Create(await _repository.ListAsync(request.Paging, cancellationToken), 200, 500, _globalStringLocalizer.GetString(Core.Resources.Application.GlobalConstants.InternalServerError))
                .Map(_mapper.Map<IEnumerable<UserDto>>);
        }
    }
}
