namespace Domain.DataTransferObject.Identity;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record UserRoleDto
{
    [Required, DisplayName("User id")] public Guid UserId { get; set; }
    [Required, DisplayName("Role id")] public Guid RoleId { get; set; }

    public UserRoleDto(Guid userId, Guid roleId)
    {
        this.UserId = userId;
        this.RoleId = roleId;
    }
}
