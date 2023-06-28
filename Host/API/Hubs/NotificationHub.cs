namespace API.Hubs;

using Domain.DataTransferObject;
using Domain.Entities.Identity;
using Domain.Mapper;
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
    private static readonly SignalRConnectionMapping<string> _connections = new();
    private readonly string _notificationMethod = "Notification";

    private readonly UserManager<User> _userManager;
    private readonly ILogger _logger;

    public NotificationHub(
        UserManager<User> userManager,
        ILogger<NotificationHub> logger)
    {
        this._userManager = userManager;
        this._logger = logger;
    }

    public override async Task OnConnectedAsync()
    {
        var id = this._userManager.GetUserId(this.Context.User);

        _connections.Add(id, this.Context.ConnectionId);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        if (exception is not null)
        {
            this._logger.LogWarning(exception: exception, message: null, args: null);
        }

        var id = this._userManager.GetUserId(this.Context.User);

        _connections.Remove(id, this.Context.ConnectionId);

        await base.OnDisconnectedAsync(exception);
    }

    public async Task NotifyAll(NotificationDto notification)
    {
        await this.Clients.All.SendAsync(this._notificationMethod, notification);
    }

    public Task NotifyUser(NotificationDto notification, string userId)
    {
        foreach (var connectionId in _connections.GetConnections(userId))
        {
            _ = this.Clients.Client(connectionId).SendAsync(this._notificationMethod, notification);
        }

        return Task.CompletedTask;
    }

    public Task NotifyUsers(NotificationDto notification, params string[] userIds)
    {
        foreach (var userId in userIds)
        {
            _ = this.NotifyUser(notification, userId);
        }

        return Task.CompletedTask;
    }

    public async Task NotifyRole(NotificationDto notification, string roleId)
    {
        var userIds = (await this._userManager.GetUsersInRoleAsync(roleId)).Select(x =>
        {
            return x.Id.ToString();
        }).ToArray();

        await this.NotifyUsers(notification, userIds);
    }

    public async Task NotifyRoles(NotificationDto notification, params string[] roleIds)
    {
        foreach (var roleId in roleIds)
        {
            await this.NotifyRole(notification, roleId);
        }
    }
}
