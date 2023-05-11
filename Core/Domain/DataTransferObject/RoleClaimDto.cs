namespace Domain.DataTransferObject;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record RoleClaimDto
{
    [Required, DisplayName("Id")] public int Id { get; set; }
    [Required, DisplayName("Role id")] public Guid RoleId { get; set; }
    [Required, DisplayName("Type")] public string ClaimType { get; set; }
    [Required, DisplayName("Value")] public string ClaimValue { get; set; }

    public RoleClaimDto(int id, Guid roleId, string claimType, string claimValue)
    {
        this.Id = id;
        this.RoleId = roleId;
        this.ClaimType = claimType;
        this.ClaimValue = claimValue;
    }
}
