namespace Application.Handlers.Identity.RoleClaim;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Extensions;
using Domain.Interface;
using Domain.Interface.Helper;
using Domain.Queries.Identity.RoleClaim;
using Domain.Resources.Application.Services.Identity.RoleClaim;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class GetRoleClaimByIdQueryHandler : IRequestHandler<GetRoleClaimByIdQuery, Result<RoleClaimDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;

    public GetRoleClaimByIdQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetRoleClaimByIdQueryHandler> logger,
        IStringLocalizerHelper stringLocalizerHelper)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(RoleClaimService));
    }

    public async Task<Result<RoleClaimDto>> Handle(GetRoleClaimByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.RoleClaims.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken), 200, 404, this._stringLocalizer.GetString(RoleClaimService.RoleClaimNotFound))
            .Map(this._mapper.Map<RoleClaimDto>);
    }
}
