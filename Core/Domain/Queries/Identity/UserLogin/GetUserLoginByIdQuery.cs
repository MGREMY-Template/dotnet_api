namespace Domain.Queries.Identity.UserLogin;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetUserLoginByIdQuery : IRequest<Result<UserLoginDto>>
{
    [Required] public string LoginProvider { get; set; }
    [Required] public string ProviderKey { get; set; }
}
