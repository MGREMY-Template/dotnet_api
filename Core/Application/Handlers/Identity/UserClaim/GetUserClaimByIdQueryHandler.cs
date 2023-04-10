namespace Application.Handlers.Identity.UserClaim;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserClaimController;
using Domain.Interface;
using Domain.Queries.Identity.UserClaim;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
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
        IStringLocalizer<Domain.Resources.Application.Services.Identity.UserClaimService> stringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<UserClaimDto>> Handle(GetUserClaimByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserClaims.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken), 200, 404, this._stringLocalizer.GetString(Domain.Resources.Application.Services.Identity.UserClaimServiceConstants.UserClaimNotFound))
            .Map(this._mapper.Map<UserClaimDto>);
    }
}
