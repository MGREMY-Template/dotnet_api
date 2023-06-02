namespace API.Hubs;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class NotificationHub : Hub
{
    private readonly string _notificationMethod = "Notification";

    private readonly UserManager<User> _userManager;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public NotificationHub(
        UserManager<User> userManager,
        ILogger<NotificationHub> logger,
        IMapper mapper)
    {
        this._userManager = userManager;
        this._logger = logger;
        this._mapper = mapper;
    }

    public override async Task OnConnectedAsync()
    {
        var user = await this._userManager.GetUserAsync(this.Context.User);
        var roles = await this._userManager.GetRolesAsync(user);

        foreach (var role in roles)
        {
            await this.Groups.AddToGroupAsync(user.Id.ToString(), role);
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        if (exception is not null)
        {
            this._logger.LogWarning(exception: exception, message: null, args: null);
        }

        var user = await this._userManager.GetUserAsync(this.Context.User);
        var roles = await this._userManager.GetRolesAsync(user);

        foreach (var role in roles)
        {
            await this.Groups.RemoveFromGroupAsync(user.Id.ToString(), role);
        }

        await base.OnDisconnectedAsync(exception);
    }

    public async Task NotifyAll(NotificationDto notification)
    {
        await this.Clients.All.SendAsync(this._notificationMethod, notification);
    }

    public async Task NotifyUser(NotificationDto notification, UserDto user)
    {
        await this.Clients.User(this._mapper.Map<User>(user).Id.ToString())
            .SendAsync(this._notificationMethod, notification);
    }

    public async Task NotifyUsers(NotificationDto notification, params UserDto[] users)
    {
        await this.Clients.Users(this._mapper.Map<User[]>(users).Select(x =>
        {
            return x.Id.ToString();
        })).SendAsync(this._notificationMethod, notification);
    }

    public async Task NotifyRole(NotificationDto notification, RoleDto role)
    {
        await this.Clients.Group(this._mapper.Map<Role>(role).Name)
            .SendAsync(this._notificationMethod, notification);
    }

    public async Task NotifyRoles(NotificationDto notification, params RoleDto[] roles)
    {
        await this.Clients.Groups(this._mapper.Map<Role[]>(roles).Select(x =>
        {
            return x.Name;
        })).SendAsync(this._notificationMethod, notification);
    }
}
