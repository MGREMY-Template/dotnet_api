namespace Domain.Queries.Identity.UserToken;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;
using System;

public class GetUserTokenByIdQuery : IRequest<Result<UserTokenDto>>
{
    public Guid UserId { get; set; }
    public string LoginProvider { get; set; }
    public string Name { get; set; }
}
