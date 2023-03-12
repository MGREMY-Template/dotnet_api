using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Shared.Application.Extensions;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController;
using Shared.Core.Entities.Identity;
using Shared.Core.Extensions;
using Shared.Core.Queries.Auth.Auth;
using Shared.Core.Resources.Services.Auth;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Application.Handlers.Auth.Auth
{
    public class ConfirmEmailQueryHandler : IRequestHandler<ConfirmEmailQuery, Result<ConfirmEmailOutput>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer _stringLocalizer;

        public ConfirmEmailQueryHandler(
            UserManager<User> userManager,
            IStringLocalizer<Core.Resources.Services.Auth.AuthService> stringLocalizer)
        {
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Result<ConfirmEmailOutput>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Input.Email);

            return Result.Create(user)
                .Ensure(x => x is not null,
                    _stringLocalizer.GetString(AuthServiceConstants.UserFindNotFound).ToStringArray())
                .Ensure(x => !x.EmailConfirmed,
                    _stringLocalizer.GetString(AuthServiceConstants.EmailConfirmAlreadyConfirmed).ToStringArray())
                .EnsureAsync(async x =>
                {
                    var result = await _userManager.ConfirmEmailAsync(x, request.Input.Token);

                    return (result.Succeeded, result.ErrorsToStringArray());
                })
                .Map(async x =>
                {
                    x = await _userManager.FindByEmailAsync(x.Email);

                    return new ConfirmEmailOutput
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        Email = x.Email
                    };
                });
        }
    }
}
