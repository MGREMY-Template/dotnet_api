namespace Application.Handlers.Identity.User;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserController;
using Domain.Interface;
using Domain.Queries.Identity.User;
using Domain.Resources.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;

public sealed class GetAllUserQueryHandler : IRequestHandler<GetUserAllQuery, Result<UserDto[]>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;

    public GetAllUserQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetAllUserQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Global> globalStringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = globalStringLocalizer;
    }

    public async Task<Result<UserDto[]>> Handle(GetUserAllQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.Users.ToArrayAsync(cancellationToken), 200, 400, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<UserDto[]>);
    }
}
