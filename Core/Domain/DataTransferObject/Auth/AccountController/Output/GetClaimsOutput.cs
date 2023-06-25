namespace Domain.DataTransferObject.Auth.AccountController.Output;

using Domain.DataTransferObject.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record GetClaimsOutput
{
    [Required, DisplayName("UserClaims")] public ClaimDto[] UserClaims { get; set; }
}
