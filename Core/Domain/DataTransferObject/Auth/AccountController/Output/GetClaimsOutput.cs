namespace Domain.DataTransferObject.Auth.AccountController.Output;

using Domain.DataTransferObject.Identity;

public record GetClaimsOutput
{
    public ClaimDto[] UserClaims { get; set; }
}
