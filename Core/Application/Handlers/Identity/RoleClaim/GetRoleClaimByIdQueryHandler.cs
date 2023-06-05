namespace Application.Handlers.Identity.RoleClaim;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.Interface;
using Domain.Queries.Identity.RoleClaim;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.DataTransferObject.Identity;

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
        IStringLocalizer<Domain.Resources.Application.Services.Identity.RoleClaimService> stringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<RoleClaimDto>> Handle(GetRoleClaimByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.RoleClaims.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken), 200, 404, this._stringLocalizer.GetString(Domain.Resources.Application.Services.Identity.RoleClaimService.RoleClaimNotFound))
            .Map(this._mapper.Map<RoleClaimDto>);
    }
}
