using System;

namespace Shared.Core.DataTransferObject.Identity.UserController
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public UserDto(Guid id, string userName, string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
        }
    }
}
