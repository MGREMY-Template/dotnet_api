﻿namespace Application.Handlers.Identity.UserToken;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Domain.Extensions;
using Domain.Interface;
using Domain.Interface.Helper;
using Domain.Queries.Identity.UserToken;
using Domain.Resources.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class GetAllUserTokenQueryHandler : IRequestHandler<GetUserTokenAllQuery, Result<UserTokenDto[]>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;

    public GetAllUserTokenQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetAllUserTokenQueryHandler> logger,
        IStringLocalizerHelper stringLocalizerHelper)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(GlobalConstants));
    }

    public async Task<Result<UserTokenDto[]>> Handle(GetUserTokenAllQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.UserTokens.ToArrayAsync(cancellationToken), 200, 400, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<UserTokenDto[]>);
    }
}
