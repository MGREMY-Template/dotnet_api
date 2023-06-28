namespace Application.Handlers.Application.AppFile;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Application;
using Domain.Interface.Helper;
using Domain.Interface;
using Domain.Queries.Applciation.AppFile;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Extensions;
using Domain.Resources.Application.Services.Application.AppFile;

public class GetAppFileByIdQueryHandler : IRequestHandler<GetAppFileByIdQuery, Result<AppFileDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;
    private readonly IAppFileHelper _appFileHelper;
    private readonly IConfiguration _configuration;

    public GetAppFileByIdQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<GetAppFileByIdQueryHandler> logger,
        IStringLocalizerHelper stringLocalizerHelper,
        IAppFileHelper appFileHelper,
        IConfiguration configuration)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._stringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(AppFileServiceConstants));
        this._appFileHelper = appFileHelper;
        this._configuration = configuration;
    }

    public async Task<Result<AppFileDto>> Handle(GetAppFileByIdQuery request, CancellationToken cancellationToken)
    {
        return Result.Create(await this._context.AppFiles.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken), 200, 400, this._stringLocalizer.GetString(AppFileServiceConstants.FileNotFound))
        .Map(this._mapper.Map<AppFileDto>);
    }
}
