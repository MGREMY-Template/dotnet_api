namespace Application.Handlers.Application.AppFile;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Application;
using Domain.Extensions;
using Domain.Interface;
using Domain.Interface.Helper;
using Domain.Queries.Applciation.AppFile;
using Domain.Resources.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class GetListAppFileQueryHandler : IRequestHandler<GetAppFileListQuery, Result<AppFileDto[]>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;
    private readonly IAppFileHelper _appFileHelper;
    private readonly IConfiguration _configuration;

    public GetListAppFileQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetListAppFileQueryHandler> logger,
        IStringLocalizerHelper stringLocalizerHelper,
        IAppFileHelper appFileHelper,
        IConfiguration configuration)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(GlobalConstants));
        this._appFileHelper = appFileHelper;
        this._configuration = configuration;
    }

    public async Task<Result<AppFileDto[]>> Handle(GetAppFileListQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.AppFiles.AsQueryable().ApplyPaging(request.Paging).ToArrayAsync(cancellationToken), 200, 400, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<AppFileDto[]>);
    }
}
