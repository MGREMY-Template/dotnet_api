namespace Application.Handlers.Application.AppFile;

using Domain.Extensions;
using Domain.Helpers;
using Domain.Interface;
using Domain.Interface.Helper;
using Domain.Queries.Applciation.AppFile;
using Domain.Resources.Application.Services.Application.AppFile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAppFileStreamQueryHandler : IRequestHandler<GetAppFileStreamQuery, PhysicalFileResult>
{
    private readonly IAppDbContext _context;
    private readonly ILogger _logger;
    private readonly IAppFileHelper _appFileHelper;
    private readonly IConfiguration _configuration;

    public GetAppFileStreamQueryHandler(
        IAppDbContext context,
        ILogger<GetAppFileStreamQueryHandler> logger,
        IAppFileHelper appFileHelper,
        IStringLocalizer<AppFileService> stringLocalizer,
        IConfiguration configuration)
    {
        this._context = context;
        this._logger = logger;
        this._appFileHelper = appFileHelper;
        this._configuration = configuration;
    }

    public Task<PhysicalFileResult> Handle(GetAppFileStreamQuery request, CancellationToken cancellationToken)
    {
        var appFile = this._context.AppFiles.FirstOrDefault(x => x.Id.Equals(request.AppFileId));

        return appFile is null
            ? null
            : Task.FromResult(new PhysicalFileResult(this._appFileHelper.GetFullPath(appFile.Id.ToString(), this._configuration), appFile.MimeType));
    }
}
