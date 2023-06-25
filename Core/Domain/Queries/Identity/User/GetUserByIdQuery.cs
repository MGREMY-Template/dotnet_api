namespace Domain.Queries.Identity.User;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

public class GetUserByIdQuery : IRequest<Result<UserDto>>
{
    [Required] public Guid Id { get; set; }
}
