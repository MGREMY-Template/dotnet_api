namespace Application.Handlers.Identity.UserToken;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.Interface;
using Domain.Queries.Identity.UserToken;
using Domain.Resources.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;
using Domain.DataTransferObject.Identity;

public class GetAllUserTokenQueryHandler : IRequestHandler<GetUserTokenAllQuery, Result<UserTokenDto[]>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;

    public GetAllUserTokenQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetAllUserTokenQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Global> globalStringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = globalStringLocalizer;
    }

    public async Task<Result<UserTokenDto[]>> Handle(GetUserTokenAllQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserTokens.ToArrayAsync(cancellationToken), 200, 400, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<UserTokenDto[]>);
    }
}
