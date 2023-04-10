namespace Application.Handlers.Identity.UserLogin;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserLoginController;
using Domain.Interface;
using Domain.Queries.Identity.UserLogin;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;

public class GetUserLoginByIdQueryHandler : IRequestHandler<GetUserLoginByIdQuery, Result<UserLoginDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;

    public GetUserLoginByIdQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetUserLoginByIdQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Services.Identity.UserLoginService> stringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<UserLoginDto>> Handle(GetUserLoginByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserLogins.FirstOrDefaultAsync(x => x.LoginProvider.Equals(request.LoginProvider) && x.ProviderKey.Equals(request.ProviderKey), cancellationToken), 200, 404, this._stringLocalizer.GetString(Domain.Resources.Application.Services.Identity.UserLoginServiceConstants.UserLoginNotFound))
            .Map(this._mapper.Map<UserLoginDto>);
    }
}
