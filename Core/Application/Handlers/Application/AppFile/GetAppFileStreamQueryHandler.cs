namespace Application.Handlers.Application.AppFile;

using Domain.DataTransferObject;
using Domain.Extensions;
using Domain.Interface;
using Domain.Interface.Helper;
using Domain.Queries.Applciation.AppFile;
using Domain.Resources.Application.Services.Application.AppFile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAppFileStreamQueryHandler : IRequestHandler<GetAppFileStreamQuery, PhysicalFileResult>
{
    private readonly IAppDbContext _context;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;
    private readonly IAppFileHelper _appFileHelper;
    private readonly IConfiguration _configuration;

    public GetAppFileStreamQueryHandler(
        IAppDbContext context,
        ILogger<GetAppFileStreamQueryHandler> logger,
        IStringLocalizer<AppFileService> stringLocalizer,
        IAppFileHelper appFileHelper,
        IConfiguration configuration)
    {
        this._context = context;
        this._logger = logger;
        this._stringLocalizer = stringLocalizer;
        this._appFileHelper = appFileHelper;
        this._configuration = configuration;
    }

    public Task<PhysicalFileResult> Handle(GetAppFileStreamQuery request, CancellationToken cancellationToken)
    {
        var appFile = this._context.AppFiles.FirstOrDefault(x => x.Id.Equals(request.AppFileId));
        if (appFile is null)
        {
            return null;
        }

        return Task.FromResult(new PhysicalFileResult(Path.Combine(this._configuration.GetFromEnvironmentVariable("DATA_DIR"), "APP_FILE", request.AppFileId.ToString()), appFile.MimeType));
    }
}
