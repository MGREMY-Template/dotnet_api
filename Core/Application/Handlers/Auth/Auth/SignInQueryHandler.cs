namespace Application.Handlers.Auth.Auth;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AuthController.Output;
using Domain.Entities.Identity;
using Domain.Extensions;
using Domain.Queries.Auth.Auth;
using Domain.Resources.Application.Services.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        IStringLocalizer<Domain.Resources.Application.Services.Auth.AuthService> stringLocalizer)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._configuration = configuration;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<SignInOutput>> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        User user = await this._userManager.FindByEmailAsync(request.Email);

        return Result.Create(user, 200, 404, this._stringLocalizer.GetString(AuthServiceConstants.UserNotFound))
            .EnsureAsync(this._signInManager.CanSignInAsync, 400, this._stringLocalizer.GetString(AuthServiceConstants.UserSignInError))
            .EnsureAsync(async x =>
            {
                return await this._userManager.CheckPasswordAsync(x, request.Password);
            }, 400, this._stringLocalizer.GetString(AuthServiceConstants.PasswordIncorrect))
            .MapAsync(async x =>
            {
                _ = this._configuration.AsEnumerable();
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration.GetFromEnvironmentVariable("JWT", "KEY")));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var userRoles = (await this._userManager.GetRolesAsync(x)).Select(role =>
                    {
                        return new Claim(ClaimTypes.Role, role);
                    });
                var userClaims = await this._userManager.GetClaimsAsync(x);
                var dataClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, x.Id.ToString()),
                };

                var tokenOptions = new JwtSecurityToken(this._configuration.GetFromEnvironmentVariable("JWT", "ISSUER"),
                    this._configuration.GetFromEnvironmentVariable("JWT", "AUDIENCE"),
                    userRoles.Concat(userClaims).Concat(dataClaims),
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
