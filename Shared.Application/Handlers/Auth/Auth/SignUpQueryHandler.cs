using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Shared.Application.Extensions;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;
using Shared.Core.Entities.Identity;
using Shared.Core.Extensions;
using Shared.Core.Queries.Auth.Auth;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Application.Handlers.Auth.Auth
{
    public class SignUpQueryHandler : IRequestHandler<SignUpQuery, Result<SignUpOutput>>
    {
        private readonly UserManager<User> _userManager;

        public SignUpQueryHandler(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<SignUpOutput>> Handle(SignUpQuery request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.Input.Email,
                Email = request.Input.Email,
            };

            return Result.Create(user, 201, 500)
                .EnsureAsync(async x =>
                {
                    var result = await _userManager.CreateAsync(x, request.Input.Password);

                    return (result.Succeeded, result.Errors.Select(x => x.Description).ToArray());
                }, 400)
                .MapAsync(async x =>
                {
                    x = await _userManager.FindByEmailAsync(x.Email);

                    return new SignUpOutput
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        Email = x.Email
                    };
                });
        }
    }
}
