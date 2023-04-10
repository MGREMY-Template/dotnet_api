namespace API.Hubs;

using AutoMapper;
using Domain.DataTransferObject.Identity.RoleController;
using Domain.DataTransferObject.Identity.UserController;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRSwaggerGen.Attributes;
using System;
using System.Linq;
using System.Threading.Tasks;

[SignalRHub]
[Authorize]
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

    public async Task NotifyAll(string title, string message)
    {
        await this.Clients.All.SendAsync(this._notificationMethod, title, message);
    }

    public async Task NotifyUser(string title, string message, UserDto user)
    {
        await this.Clients.User(this._mapper.Map<User>(user).Id.ToString())
            .SendAsync(this._notificationMethod, title, message);
    }

    public async Task NotifyUsers(string title, string message, params UserDto[] users)
    {
        await this.Clients.Users(this._mapper.Map<User[]>(users).Select(x =>
        {
            return x.Id.ToString();
        })).SendAsync(this._notificationMethod, title, message);
    }

    public async Task NotifyRole(string title, string message, RoleDto role)
    {
        await this.Clients.Group(this._mapper.Map<Role>(role).Name)
            .SendAsync(this._notificationMethod, title, message);
    }

    public async Task NotifyRoles(string title, string message, params RoleDto[] roles)
    {
        await this.Clients.Groups(this._mapper.Map<Role[]>(roles).Select(x =>
        {
            return x.Name;
        })).SendAsync(this._notificationMethod, title, message);
    }
}
