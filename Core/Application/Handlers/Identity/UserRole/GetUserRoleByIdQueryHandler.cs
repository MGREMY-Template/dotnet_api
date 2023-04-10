namespace Application.Handlers.Identity.UserRole;

using Application.Handlers.Identity.Role;
using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.RoleController;
using Domain.DataTransferObject.Identity.UserRoleController;
using Domain.Interface;
using Domain.Queries.Identity.UserRole;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
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
        IStringLocalizer<Domain.Resources.Application.Services.Identity.UserRoleService> stringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<UserRoleDto>> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserRoles.FirstOrDefaultAsync(x => x.UserId.Equals(request.UserId) && x.RoleId.Equals(request.RoleId), cancellationToken), 200, 404, this._stringLocalizer.GetString(Domain.Resources.Application.Services.Identity.UserRoleServiceConstants.UserRoleNotFound))
            .Map(this._mapper.Map<UserRoleDto>);
    }
}
