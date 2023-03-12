using System;

namespace Shared.Core.DataTransferObject.Identity.UserTokenController
{
    public record UserTokenDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public UserTokenDto(Guid id, Guid userId, string loginProvider, string name, string value)
        {
            Id = id;
            UserId = userId;
            LoginProvider = loginProvider;
            Name = name;
            Value = value;
        }
    }
}
