namespace Domain.DataTransferObject;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record UserTokenDto
{
    [Required, DisplayName("User id")] public Guid UserId { get; set; }
    [Required, DisplayName("Login provider")] public string LoginProvider { get; set; }
    [Required, DisplayName("Name")] public string Name { get; set; }
    [Required, DisplayName("Value")] public string Value { get; set; }

    public UserTokenDto(Guid userId, string loginProvider, string name, string value)
    {
        this.UserId = userId;
        this.LoginProvider = loginProvider;
        this.Name = name;
        this.Value = value;
    }
}
