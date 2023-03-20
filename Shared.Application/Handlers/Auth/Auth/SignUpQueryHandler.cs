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

public class SignUpQueryHandler : IRequestHandler<SignUpQuery, Result<SignUpOutput>>
{
    private readonly UserManager<User> _userManager;
    private readonly IStringLocalizer _globalStringLocalizer;

    public SignUpQueryHandler(
        UserManager<User> userManager,
        IStringLocalizer<Core.Resources.Application.Global> globalStringLocalizer)
    {
        this._userManager = userManager;
        this._globalStringLocalizer = globalStringLocalizer;
    }

    public async Task<Result<SignUpOutput>> Handle(SignUpQuery request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.Input.Email,
            Email = request.Input.Email,
        };

        return Result.Create(user, 201, 500, this._globalStringLocalizer.GetString(Core.Resources.Application.GlobalConstants.InternalServerError))
            .EnsureAsync(async x =>
            {
                IdentityResult result = await this._userManager.CreateAsync(x, request.Input.Password);

                return (result.Succeeded, result.ErrorsToStringArray());
            }, 400)
            .MapAsync(async x =>
            {
                x = await this._userManager.FindByEmailAsync(x.Email);

                return new SignUpOutput
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email
                };
            });
    }
}
