namespace Application.Handlers.Auth.Account;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.DataTransferObject.Auth.AccountController.Output;
using Domain.DataTransferObject.Identity;
using Domain.Entities.Identity;
using Domain.Extensions;
using Domain.Interface.Helper;
using Domain.Queries.Auth.Account;
using Domain.Resources.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetClaimsQueryHandler : IRequestHandler<GetClaimsQuery, Result<GetClaimsOutput>>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IStringLocalizer _globalStringLocalizer;
    private readonly RoleManager<Role> _roleManager;

    public GetClaimsQueryHandler(
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IStringLocalizerHelper stringLocalizerHelper)
    {
        this._httpContextAccessor = httpContextAccessor;
        this._mapper = mapper;
        this._userManager = userManager;
        this._roleManager = roleManager;
        this._globalStringLocalizer = stringLocalizerHelper.GetStringLocalizer(typeof(GlobalConstants));
    }

    public async Task<Result<GetClaimsOutput>> Handle(GetClaimsQuery request, CancellationToken cancellationToken)
    {
        User user = await this._userManager.GetUserAsync(this._httpContextAccessor.HttpContext.User);

        return Result.Create(user, 200, 500, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .MapAsync(async x =>
            {
                ICollection<System.Security.Claims.Claim> userClaims = await this._userManager.GetClaimsAsync(x);

                return new GetClaimsOutput
                {
                    UserClaims = this._mapper.Map<ClaimDto[]>(userClaims),
                };
            });
    }
}
