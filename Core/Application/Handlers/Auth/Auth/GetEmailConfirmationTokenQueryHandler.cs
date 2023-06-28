namespace Application.Handlers.Auth.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AuthController.Output;
using Domain.Entities.Identity;
using Domain.Extensions;
using Domain.Interface.Helper;
using Domain.Queries.Auth.Auth;
using Domain.Resources.Application.Services.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class GetEmailConfirmationTokenQueryHandler : IRequestHandler<GetEmailConfirmationTokenQuery, Result<GetEmailConfirmationTokenOutput>>
{
    private readonly UserManager<User> _userManager;
    private readonly IStringLocalizer _stringLocalizer;

    public GetEmailConfirmationTokenQueryHandler(
        UserManager<User> userManager,
        IStringLocalizerHelper stringLocalizerHelper)
    {
        this._userManager = userManager;
        this._stringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(AuthServiceConstants));
    }

    public async Task<Result<GetEmailConfirmationTokenOutput>> Handle(GetEmailConfirmationTokenQuery request, CancellationToken cancellationToken)
    {
        User user = await this._userManager.FindByEmailAsync(request.Email);

        return Result.Create(user, 200, 404, this._stringLocalizer.GetString(AuthServiceConstants.UserNotFound))
            .Ensure(x =>
            {
                return !x.EmailConfirmed;
            }, 400, this._stringLocalizer.GetString(AuthServiceConstants.EmailAlreadyConfirmed))
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
