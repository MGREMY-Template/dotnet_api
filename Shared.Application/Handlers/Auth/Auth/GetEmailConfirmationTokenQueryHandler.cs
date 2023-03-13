namespace Shared.Application.Handlers.Auth.Auth;

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;
using Shared.Core.Entities.Identity;
using Shared.Core.Extensions;
using Shared.Core.Queries.Auth.Auth;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class GetEmailConfirmationTokenQueryHandler : IRequestHandler<GetEmailConfirmationTokenQuery, Result<GetEmailConfirmationTokenOutput>>
{
    private readonly UserManager<User> _userManager;
    private readonly IStringLocalizer _stringLocalizer;

    public GetEmailConfirmationTokenQueryHandler(
        UserManager<User> userManager,
        IStringLocalizer<Core.Resources.Application.Services.Auth.AuthService> stringLocalizer)
    {
        this._userManager = userManager;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<GetEmailConfirmationTokenOutput>> Handle(GetEmailConfirmationTokenQuery request, CancellationToken cancellationToken)
    {
        User user = await this._userManager.FindByEmailAsync(request.Input.Email);

        return Result.Create(user, 200, 404, this._stringLocalizer.GetString(Core.Resources.Application.Services.Auth.AuthServiceConstants.UserNotFound))
            .Ensure(x => !x.EmailConfirmed, 400, this._stringLocalizer.GetString(Core.Resources.Application.Services.Auth.AuthServiceConstants.EmailAlreadyConfirmed))
            .MapAsync(async x =>
            {
                var token = await this._userManager.GenerateEmailConfirmationTokenAsync(x);

                return new GetEmailConfirmationTokenOutput
                {
                    Token = token,
                };
            });
    }
}
