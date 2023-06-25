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
using Domain.Resources.Application.Services.Application.AppFile;
using Domain.Extensions;
using System.IO;
using Domain.Resources.Application;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

public class PostAppFileQueryHandler : IRequestHandler<PostAppFileQuery, Result<AppFileDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IStringLocalizer _globalStringLocalizer;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _userManager;
    private readonly IAppFileHelper _appFileHelper;
    private readonly IConfiguration _configuration;
    private readonly IStringLocalizer _appFileStringLocalizer;

    public PostAppFileQueryHandler(
        IAppDbContext context,
        IMapper mapper,
        ILogger<PostAppFileQueryHandler> logger,
        IStringLocalizer<Domain.Resources.Application.Global> globalStringLocalizer,
        UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor,
        IAppFileHelper appFileHelper,
        IConfiguration configuration,
        IStringLocalizer<AppFileService> appFileStringLocalizer)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
        this._globalStringLocalizer = globalStringLocalizer;
        this._userManager = userManager;
        this._httpContextAccessor = httpContextAccessor;
        this._appFileHelper = appFileHelper;
        this._configuration = configuration;
        this._appFileStringLocalizer = appFileStringLocalizer;
    }

    public async Task<Result<AppFileDto>> Handle(PostAppFileQuery request, CancellationToken cancellationToken)
    {
        if (request.File.Length == 0)
        {
            return Result<AppFileDto>.Failure(400, this._appFileStringLocalizer.GetString(AppFileServiceConstants.FileIsEmpty));
        }

        var newAppFile = new Domain.Entities.Application.AppFile
        {
            UserId = (await this._userManager.GetUserAsync(this._httpContextAccessor.HttpContext.User)).Id,
            Size = request.File.Length,
            MimeType = request.File.ContentType,
            Content = request.File.OpenReadStream(),
        };

        this._context.AppFiles.Add(newAppFile);

        await this._appFileHelper.WriteContent(Path.Combine(this._configuration.GetFromEnvironmentVariable("DATA_DIR"), "APP_FILE"), newAppFile.Id.ToString(), newAppFile.Content, cancellationToken);

        await this._context.SaveChangesAsync();

        return Result.Create(newAppFile, 200, 500, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .Map(this._mapper.Map<AppFileDto>);
    }
}
