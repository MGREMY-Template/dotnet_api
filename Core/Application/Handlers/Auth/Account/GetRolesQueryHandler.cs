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

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, Result<GetRolesOutput>>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IStringLocalizer _globalStringLocalizer;
    private readonly RoleManager<Role> _roleManager;

    public GetRolesQueryHandler(
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

    public async Task<Result<GetRolesOutput>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var user = await this._userManager.GetUserAsync(this._httpContextAccessor.HttpContext.User);

        return Result.Create(user, 200, 500, this._globalStringLocalizer.GetString(GlobalConstants.InternalServerError))
            .MapAsync(async x =>
            {
                var roles = new List<Role>();

                foreach (var role in await this._userManager.GetRolesAsync(x))
                {
                    roles.Add(await this._roleManager.FindByNameAsync(role));
                }

                return new GetRolesOutput
                {
                    Roles = this._mapper.Map<RoleDto[]>(roles),
                };
            });
    }
}
