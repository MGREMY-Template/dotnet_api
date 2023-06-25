namespace Domain.DataTransferObject.Identity;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public record UserDto
{
    [Required, DisplayName("Id")] public Guid Id { get; set; }
    [Required, DisplayName("User name")] public string UserName { get; set; }
    [Required, EmailAddress, DisplayName("Email")] public string Email { get; set; }

    public UserDto(Guid id, string userName, string email)
    {
        this.Id = id;
        this.UserName = userName;
        this.Email = email;
    }
}
