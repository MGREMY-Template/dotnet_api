namespace Application.Handlers.Identity.User;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Extensions;
using Domain.Interface;
using Domain.Interface.Helper;
using Domain.Queries.Identity.User;
using Domain.Resources.Application.Services.Identity.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;

    public GetUserByIdQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetUserByIdQueryHandler> logger,
        IStringLocalizerHelper stringLocalizerHelper)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(UserServiceConstants));
    }

    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken), 200, 404, this._stringLocalizer.GetString(UserServiceConstants.UserNotFound))
            .Map(this._mapper.Map<UserDto>);
    }
}
