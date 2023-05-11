namespace Application.Handlers.Auth.Auth;

using Application.Extensions;
using AutoMapper;
using Domain.DataTransferObject;
using Domain.Entities.Identity;
using Domain.Queries.Auth.Auth;
using Domain.Resources.Application;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Domain.Extensions;
using System.Threading;
using System.Threading.Tasks;

public class SignUpQueryHandler : IRequestHandler<SignUpQuery, Result<UserDto>>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer _globalStringLocalizer;

    public SignUpQueryHandler(
        UserManager<User> userManager,
        IMapper mapper,
        IStringLocalizer<Domain.Resources.Application.Global> globalStringLocalizer)
    {
        this._userManager = userManager;
        this._mapper = mapper;
        this._globalStringLocalizer = globalStringLocalizer;
    }

    public async Task<Result<UserDto>> Handle(SignUpQuery request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
        };

        return Result.Create(user, 201, 500, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .EnsureAsync(async x =>
            {
                IdentityResult result = await this._userManager.CreateAsync(x, request.Password);

                return (result.Succeeded, result.ErrorsToStringArray());
            }, 400)
            .MapAsync(async x =>
            {
                x = await this._userManager.FindByEmailAsync(x.Email);

                return this._mapper.Map<UserDto>(x);
            });
    }
}
