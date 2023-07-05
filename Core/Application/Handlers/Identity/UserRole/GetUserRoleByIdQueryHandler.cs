namespace Application.Handlers.Identity.UserRole;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Extensions;
using Domain.Interface;
using Domain.Interface.Helper;
using Domain.Queries.Identity.UserRole;
using Domain.Resources.Application.Services.Identity.UserRole;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class GetUserRoleByIdQueryHandler : IRequestHandler<GetUserRoleByIdQuery, Result<UserRoleDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;

    public GetUserRoleByIdQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetUserRoleByIdQueryHandler> logger,
        IStringLocalizerHelper stringLocalizerHelper)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(UserRoleServiceConstants));
    }

    public async Task<Result<UserRoleDto>> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserRoles.FirstOrDefaultAsync(x => x.UserId.Equals(request.UserId) && x.RoleId.Equals(request.RoleId), cancellationToken), 200, 404, this._stringLocalizer.GetString(UserRoleServiceConstants.UserRoleNotFound))
            .Map(this._mapper.Map<UserRoleDto>);
    }
}
