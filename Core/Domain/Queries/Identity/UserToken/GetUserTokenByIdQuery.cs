namespace Domain.Queries.Identity.UserToken;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity.UserTokenController;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

public class GetUserTokenByIdQuery : IRequest<Result<UserTokenDto>>
{
    [Required] public Guid UserId { get; set; }
    [Required] public string LoginProvider { get; set; }
    [Required] public string Name { get; set; }
}
