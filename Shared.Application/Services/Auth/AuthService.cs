using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Shared.Application.Extensions;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController;
using Shared.Core.Entities.Identity;
using Shared.Core.Extensions;
using Shared.Core.Interface.Service.Auth;
using Shared.Core.Resources.Services.Auth;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer _stringLocalizer;

        public AuthService(
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

        public async Task<Result<SignUpOutput>> SignUpAsync(
            SignUpInput input,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = input.Email,
                Email = input.Email,
            };

            return Result.Create(user)
                .EnsureAsync(async x =>
                {
                    var result = await _userManager.CreateAsync(x, input.Password);

                    return (result.Succeeded, result.ErrorsToStringArray());
                })
                .Map(async x =>
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

        public async Task<Result<GetEmailConfirmationTokenOutput>> GetEmailConfirmTokenAsync(
            GetEmailConfirmationInput input,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            return Result.Create(user)
                .Ensure(x => x is not null,
                    _stringLocalizer.GetString(AuthServiceConstants.UserFindNotFound).ToStringArray())
                .Ensure(x => !x.EmailConfirmed,
                    _stringLocalizer.GetString(AuthServiceConstants.EmailConfirmAlreadyConfirmed).ToStringArray())
                .Map(async x =>
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(x);

                    return new GetEmailConfirmationTokenOutput
                    {
                        Token = token,
                    };
                });
        }

        public async Task<Result<ConfirmEmailOutput>> ConfirmEmailAsync(
            ConfirmEmailInput input,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            return Result.Create(user)
                .Ensure(x => x is not null,
                    _stringLocalizer.GetString(AuthServiceConstants.UserFindNotFound).ToStringArray())
                .Ensure(x => !x.EmailConfirmed,
                    _stringLocalizer.GetString(AuthServiceConstants.EmailConfirmAlreadyConfirmed).ToStringArray())
                .EnsureAsync(async x =>
                {
                    var result = await _userManager.ConfirmEmailAsync(x, input.Token);

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

        public async Task<Result<SignInOutput>> SignInAsync(
            SignInInput input,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            return Result.Create(user)
                .Ensure(x => x is not null,
                    _stringLocalizer.GetString(AuthServiceConstants.UserFindNotFound).ToStringArray())
                .EnsureAsync(_signInManager.CanSignInAsync,
                    _stringLocalizer.GetString(AuthServiceConstants.UserSignInError).ToStringArray())
                .EnsureAsync(async x => await _userManager.CheckPasswordAsync(x, input.Password),
                    _stringLocalizer.GetString(AuthServiceConstants.PasswordSignInPasswordIncorrect).ToStringArray())
                .Map(async x =>
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
