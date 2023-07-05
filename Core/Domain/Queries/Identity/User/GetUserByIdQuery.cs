namespace Domain.Queries.Identity.User;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;
using System;

public class GetUserByIdQuery : IRequest<Result<UserDto>>
{
    public Guid Id { get; set; }
}
