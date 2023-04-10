namespace Application.Handlers.Identity.UserToken;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.RoleController;
using Domain.DataTransferObject.Identity.UserTokenController;
using Domain.Interface;
using Domain.Queries.Identity.UserToken;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;

public class GetUserTokenByIdQueryHandler : IRequestHandler<GetUserTokenByIdQuery, Result<UserTokenDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;

    public GetUserTokenByIdQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetUserTokenByIdQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Services.Identity.UserTokenService> stringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<UserTokenDto>> Handle(GetUserTokenByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserTokens.FirstOrDefaultAsync(x => x.UserId.Equals(request.UserId) && x.LoginProvider.Equals(request.LoginProvider) && x.Name.Equals(request.Name), cancellationToken), 200, 404, this._stringLocalizer.GetString(Domain.Resources.Application.Services.Identity.UserTokenServiceConstants.UserTokenNotFound))
            .Map(this._mapper.Map<UserTokenDto>);
    }
}
