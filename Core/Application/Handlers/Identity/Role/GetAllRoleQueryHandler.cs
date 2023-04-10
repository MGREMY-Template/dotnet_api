namespace Application.Handlers.Identity.Role;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.RoleController;
using Domain.Extensions;
using Domain.Interface;
using Domain.Queries.Identity.Role;
using Domain.Resources.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class GetAllRoleQueryHandler : IRequestHandler<GetRoleAllQuery, Result<RoleDto[]>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;

    public GetAllRoleQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetAllRoleQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Global> globalStringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = globalStringLocalizer;
    }

    public async Task<Result<RoleDto[]>> Handle(GetRoleAllQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.Roles.ToArrayAsync(cancellationToken), 200, 400, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<RoleDto[]>);
    }
}
