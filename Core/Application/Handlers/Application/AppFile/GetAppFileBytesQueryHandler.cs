namespace Application.Handlers.Application.AppFile;

using Domain.Interface.Helper;
using Domain.Interface;
using Domain.Queries.Applciation.AppFile;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Domain.Extensions;
using Domain.DataTransferObject;
using Domain.Resources.Application.Services.Application.AppFile;
using Microsoft.Extensions.Localization;

public class GetAppFileBytesQueryHandler : IRequestHandler<GetAppFileBytesQuery, Result<byte[]>>
{
    private readonly IAppDbContext _context;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _stringLocalizer;
    private readonly IAppFileHelper _appFileHelper;
    private readonly IConfiguration _configuration;

    public GetAppFileBytesQueryHandler(
        IAppDbContext context,
        ILogger<GetAppFileBytesQueryHandler> logger,
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

    public Task<Result<byte[]>> Handle(GetAppFileBytesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Create(this._context.AppFiles.FirstOrDefault(x => x.Id.Equals(request.AppFileId)), 200, 404, this._stringLocalizer.GetString(AppFileServiceConstants.FileNotFound))
            .Ensure(x =>
            {
                return this._appFileHelper.Exists(this._appFileHelper.GetFullPath(x.Id.ToString(), this._configuration));
            }, 400, this._stringLocalizer.GetString(AppFileServiceConstants.FileIsEmpty))
            .Map(x =>
            {
                var output = this._appFileHelper.ReadByteContent(this._appFileHelper.GetFullPath(x.Id.ToString(), this._configuration));

                return output;
            }));
    }
}
