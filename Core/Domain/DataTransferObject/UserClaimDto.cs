namespace Domain.DataTransferObject;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record UserClaimDto
{
    [Required, DisplayName("Id")] public int Id { get; set; }
    [Required, DisplayName("User id")] public Guid UserId { get; set; }
    [Required, DisplayName("Type")] public string ClaimType { get; set; }
    [Required, DisplayName("Value")] public string ClaimValue { get; set; }

    public UserClaimDto(int id, Guid userId, string claimType, string claimValue)
    {
        this.Id = id;
        this.UserId = userId;
        this.ClaimType = claimType;
        this.ClaimValue = claimValue;
    }
}
