using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController.Output;
using Shared.Core.Entities.Identity;
using Shared.Core.Extensions;
using Shared.Core.Queries.Auth.Auth;
using Shared.Core.Resources.Services.Auth;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Application.Handlers.Auth.Auth
{
    public class SignInQueryHandler : IRequestHandler<SignInQuery, Result<SignInOutput>>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer _stringLocalizer;

        public SignInQueryHandler(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration,
            IStringLocalizer<Core.Resources.Services.Auth.AuthService> stringLocalizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Result<SignInOutput>> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Input.Email);

            return Result.Create(user, 200, 404, _stringLocalizer.GetString(AuthServiceConstants.UserFindNotFound))
                .EnsureAsync(_signInManager.CanSignInAsync, 400,
                    _stringLocalizer.GetString(AuthServiceConstants.UserSignInError))
                .EnsureAsync(async x => await _userManager.CheckPasswordAsync(x, request.Input.Password), 400,
                    _stringLocalizer.GetString(AuthServiceConstants.PasswordSignInPasswordIncorrect))
                .MapAsync(async x =>
                {
                    _configuration.AsEnumerable();
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetFromEnvironmentVariable("JWT", "KEY")));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = await _userManager.GetClaimsAsync(x);

                    var tokenOptions = new JwtSecurityToken(_configuration.GetFromEnvironmentVariable("JWT", "ISSUER"),
                        _configuration.GetFromEnvironmentVariable("JWT", "AUDIENCE"),
                        claims,
                        expires: DateTime.Now.AddMinutes(3600),
                        signingCredentials: credentials);

                    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                    return new SignInOutput
                    {
                        Token = token,
                    };
                });
        }
    }
}
