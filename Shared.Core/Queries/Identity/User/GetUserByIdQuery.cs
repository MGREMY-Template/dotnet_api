namespace Shared.Core.Queries.Identity.User;

using MediatR;
using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Identity.UserController;
using System;
using System.ComponentModel.DataAnnotations;

public class GetUserByIdQuery : IRequest<Result<UserDto>>
{
    [Required] public Guid Id { get; set; }
}
