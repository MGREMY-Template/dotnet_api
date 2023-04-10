namespace Application.Handlers.Identity.UserClaim;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserClaimController;
using Domain.Extensions;
using Domain.Interface;
using Domain.Queries.Identity.UserClaim;
using Domain.Resources.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class GetListUserClaimQueryHandler : IRequestHandler<GetUserClaimListQuery, Result<UserClaimDto[]>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;

    public GetListUserClaimQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetListUserClaimQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Global> globalStringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = globalStringLocalizer;
    }

    public async Task<Result<UserClaimDto[]>> Handle(GetUserClaimListQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserClaims.AsQueryable().ApplyPaging(request.Paging).ToArrayAsync(cancellationToken), 200, 500, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<UserClaimDto[]>);
    }
}
