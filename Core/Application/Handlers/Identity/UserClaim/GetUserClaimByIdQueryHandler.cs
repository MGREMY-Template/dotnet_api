namespace Application.Handlers.Identity.UserClaim;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Extensions;
using Domain.Interface;
using Domain.Interface.Helper;
using Domain.Queries.Identity.UserClaim;
using Domain.Resources.Application.Services.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class GetUserClaimByIdQueryHandler : IRequestHandler<GetUserClaimByIdQuery, Result<UserClaimDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;

    public GetUserClaimByIdQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetUserClaimByIdQueryHandler> logger,
        IStringLocalizerHelper stringLocalizerHelper)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(UserClaimServiceConstants));
    }

    public async Task<Result<UserClaimDto>> Handle(GetUserClaimByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserClaims.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken), 200, 404, this._stringLocalizer.GetString(UserClaimServiceConstants.UserClaimNotFound))
            .Map(this._mapper.Map<UserClaimDto>);
    }
}
