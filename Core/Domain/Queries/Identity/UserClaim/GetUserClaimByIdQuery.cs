namespace Domain.Queries.Identity.UserClaim;

using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class GetUserClaimByIdQuery : IRequest<Result<UserClaimDto>>
{
    [Required] public int Id { get; set; }
}
