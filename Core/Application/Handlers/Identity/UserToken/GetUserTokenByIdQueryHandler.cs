namespace Application.Handlers.Identity.UserToken;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.Interface;
using Domain.Queries.Identity.UserToken;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;
using Domain.DataTransferObject.Identity;
using Domain.Interface.Helper;
using Domain.Resources.Application.Services.Identity;

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
        IStringLocalizerHelper stringLocalizerHelper)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(UserTokenServiceConstants));
    }

    public async Task<Result<UserTokenDto>> Handle(GetUserTokenByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserTokens.FirstOrDefaultAsync(x => x.UserId.Equals(request.UserId) && x.LoginProvider.Equals(request.LoginProvider) && x.Name.Equals(request.Name), cancellationToken), 200, 404, this._stringLocalizer.GetString(UserTokenServiceConstants.UserTokenNotFound))
            .Map(this._mapper.Map<UserTokenDto>);
    }
}
