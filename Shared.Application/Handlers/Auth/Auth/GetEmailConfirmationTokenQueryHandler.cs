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

namespace Shared.Application.Handlers.Auth.Auth
{
    public class GetEmailConfirmationTokenQueryHandler : IRequestHandler<GetEmailConfirmationTokenQuery, Result<GetEmailConfirmationTokenOutput>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer _stringLocalizer;

        public GetEmailConfirmationTokenQueryHandler(
            UserManager<User> userManager,
            IStringLocalizer<Core.Resources.Application.Services.Auth.AuthService> stringLocalizer)
        {
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Result<GetEmailConfirmationTokenOutput>> Handle(GetEmailConfirmationTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Input.Email);

            return Result.Create(user, 200, 404, _stringLocalizer.GetString(Core.Resources.Application.Services.Auth.AuthServiceConstants.UserNotFound))
                .Ensure(x => !x.EmailConfirmed, 400, _stringLocalizer.GetString(Core.Resources.Application.Services.Auth.AuthServiceConstants.EmailAlreadyConfirmed))
                .MapAsync(async x =>
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(x);

                    return new GetEmailConfirmationTokenOutput
                    {
                        Token = token,
                    };
                });
        }
    }
}
