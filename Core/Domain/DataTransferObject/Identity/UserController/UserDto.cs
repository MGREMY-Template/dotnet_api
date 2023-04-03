namespace Domain.DataTransferObject.Identity.UserController;

using System;

public record UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public UserDto(Guid id, string userName, string email)
    {
        this.Id = id;
        this.UserName = userName;
        this.Email = email;
    }
}
