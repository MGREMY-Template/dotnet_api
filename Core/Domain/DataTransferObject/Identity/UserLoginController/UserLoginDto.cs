namespace Domain.DataTransferObject.Identity.UserLoginController;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record UserLoginDto
{
    [Required, DisplayName("Provider key")] public string ProviderKey { get; set; }
    [Required, DisplayName("Provider name")] public string ProviderDisplayName { get; set; }
    [Required, DisplayName("User id")] public Guid UserId { get; set; }

    public UserLoginDto(string providerKey, string providerDisplayName, Guid userId)
    {
        this.ProviderKey = providerKey;
        this.ProviderDisplayName = providerDisplayName;
        this.UserId = userId;
    }
}
