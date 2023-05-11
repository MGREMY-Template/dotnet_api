namespace Application.Handlers.Identity.RoleClaim;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.Interface;
using Domain.Queries.Identity.RoleClaim;
using Domain.Resources.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;

public class GetAllRoleClaimQueryHandler : IRequestHandler<GetRoleClaimAllQuery, Result<RoleClaimDto[]>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;

    public GetAllRoleClaimQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetAllRoleClaimQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Global> globalStringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = globalStringLocalizer;
    }

    public async Task<Result<RoleClaimDto[]>> Handle(GetRoleClaimAllQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.RoleClaims.ToArrayAsync(cancellationToken), 200, 400, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<RoleClaimDto[]>);
    }
}
