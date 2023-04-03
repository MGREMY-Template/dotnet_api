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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetListUserQueryHandler : IRequestHandler<GetUserListQuery, Result<UserDto[]>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;

    public GetListUserQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetListUserQueryHandler> logger,
        IStringLocalizer<Core.Resources.Application.Global> globalStringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = globalStringLocalizer;
    }

    public async Task<Result<UserDto[]>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.Users.AsQueryable().ApplyPaging(request.Paging).ToArrayAsync(cancellationToken), 200, 500, this._globalStringLocalizer.GetString(Core.Resources.Application.GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<UserDto[]>);
    }
}
