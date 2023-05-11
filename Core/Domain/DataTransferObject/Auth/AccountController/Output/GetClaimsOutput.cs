namespace Domain.DataTransferObject.Auth.AccountController.Output;

using Domain.DataTransferObject;

public record GetClaimsOutput
{
    public ClaimDto[] UserClaims { get; set; }
}
