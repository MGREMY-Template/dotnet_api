﻿using System;

namespace Shared.Core.DataTransferObject.Auth.AuthController.Output
{
    public record ConfirmEmailOutput
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
