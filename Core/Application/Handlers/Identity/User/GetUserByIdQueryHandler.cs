namespace Shared.Application.Handlers.Identity.User;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Extensions;
using Shared.Core.Interface;
using Shared.Core.Queries.Identity.User;
using System.Threading;
using System.Threading.Tasks;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;

    public GetUserByIdQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetUserByIdQueryHandler> logger,
        IStringLocalizer<Core.Resources.Application.Services.Identity.UserService> stringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken), 200, 404, this._stringLocalizer.GetString(Core.Resources.Application.Services.Identity.UserServiceConstants.UserNotFound))
            .Map(this._mapper.Map<UserDto>);
    }
}
