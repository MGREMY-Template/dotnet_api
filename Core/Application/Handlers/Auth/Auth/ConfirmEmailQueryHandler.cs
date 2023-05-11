namespace Application.Handlers.Auth.Auth;

using Application.Extensions;
using AutoMapper;
using Domain.DataTransferObject;
using Domain.Entities.Identity;
using Domain.Queries.Auth.Auth;
using Domain.Resources.Application.Services.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Domain.DataTransferObject.Auth.AuthController.Output;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;

public class ConfirmEmailQueryHandler : IRequestHandler<ConfirmEmailQuery, Result<UserDto>>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer _stringLocalizer;

    public ConfirmEmailQueryHandler(
        UserManager<User> userManager,
        IMapper mapper,
        IStringLocalizer<Domain.Resources.Application.Services.Auth.AuthService> stringLocalizer)
    {
        this._userManager = userManager;
        this._mapper = mapper;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<Result<UserDto>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
    {
        User user = await this._userManager.FindByEmailAsync(request.Email);

        return Result.Create(user, 200, 404, this._stringLocalizer.GetString(AuthServiceConstants.UserNotFound))
            .Ensure(x =>
            {
                return !x.EmailConfirmed;
            }, 400, this._stringLocalizer.GetString(AuthServiceConstants.EmailAlreadyConfirmed))
            .EnsureAsync(async x =>
            {
                IdentityResult result = await this._userManager.ConfirmEmailAsync(x, request.Token);

                return (result.Succeeded, result.ErrorsToStringArray());
            }, 400)
            .MapAsync(async x =>
            {
                x = await this._userManager.FindByEmailAsync(x.Email);

                return this._mapper.Map<UserDto>(x);
            });
    }
}
