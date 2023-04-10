namespace Application.Handlers.Identity.Role;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.RoleController;
using Domain.Interface;
using Domain.Queries.Identity.Role;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Result<RoleDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;

    public GetRoleByIdQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetRoleByIdQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Services.Identity.RoleService> stringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<RoleDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.Roles.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken), 200, 404, this._stringLocalizer.GetString(Domain.Resources.Application.Services.Identity.RoleServiceConstants.RoleNotFound))
            .Map(this._mapper.Map<RoleDto>);
    }
}
