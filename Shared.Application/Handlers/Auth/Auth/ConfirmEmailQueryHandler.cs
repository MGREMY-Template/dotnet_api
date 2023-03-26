namespace Shared.Application.Handlers.Auth.Auth;

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Shared.Application.Extensions;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;
using Shared.Core.Entities.Identity;
using Shared.Core.Extensions;
using Shared.Core.Queries.Auth.Auth;
using System.Threading;
using System.Threading.Tasks;

public class ConfirmEmailQueryHandler : IRequestHandler<ConfirmEmailQuery, Result<ConfirmEmailOutput>>
{
    private readonly UserManager<User> _userManager;
    private readonly IStringLocalizer _stringLocalizer;

    public ConfirmEmailQueryHandler(
        UserManager<User> userManager,
        IStringLocalizer<Core.Resources.Application.Services.Auth.AuthService> stringLocalizer)
    {
        this._userManager = userManager;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<ConfirmEmailOutput>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
    {
        User user = await this._userManager.FindByEmailAsync(request.Email);

        return Result.Create(user, 200, 404, this._stringLocalizer.GetString(Core.Resources.Application.Services.Auth.AuthServiceConstants.UserNotFound))
            .Ensure(x =>
            {
                return !x.EmailConfirmed;
            }, 400, this._stringLocalizer.GetString(Core.Resources.Application.Services.Auth.AuthServiceConstants.EmailAlreadyConfirmed))
            .EnsureAsync(async x =>
            {
                IdentityResult result = await this._userManager.ConfirmEmailAsync(x, request.Token);

                return (result.Succeeded, result.ErrorsToStringArray());
            }, 400)
            .MapAsync(async x =>
            {
                x = await this._userManager.FindByEmailAsync(x.Email);

                return new ConfirmEmailOutput
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email
                };
            });
    }
}
