﻿namespace Application.Handlers.Identity.UserRole;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserRoleController;
using Domain.Interface;
using Domain.Queries.Identity.UserRole;
using Domain.Resources.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;

public class GetAllUserRoleQueryHandler : IRequestHandler<GetUserRoleAllQuery, Result<UserRoleDto[]>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;

    public GetAllUserRoleQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetAllUserRoleQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Global> globalStringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = globalStringLocalizer;
    }

    public async Task<Result<UserRoleDto[]>> Handle(GetUserRoleAllQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserRoles.ToArrayAsync(cancellationToken), 200, 400, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<UserRoleDto[]>);
    }
}